using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private int health;
    [SerializeField] private float playerSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shotPoint;

    private Rigidbody2D rig;
    private bool isJumping;
    
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Can be used on Update, because that's just one time event each key press and doesn't involve physics
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        // if (Input.GetMouseButtonDown(0))
        // {
        //     Shoot();
        // }
    }
    
    public void Jump()
    {
        if (isJumping) return;
        
        rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        isJumping = true;
        animator.SetBool("jumping", true);
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, shotPoint.position, shotPoint.rotation);
    }

    // Update is called once per frame
    void FixedUpdate() 
    {
        rig.velocity = new Vector2(playerSpeed, rig.velocity.y);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Damage: " + damage + " / Health: " + health);
        if (health <= 0)
        {
            GameManager.instance.ShowGameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 3)
        {
            isJumping = false;
            animator.SetBool("jumping", false);    
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bomb"))
        {
            // Debug.Log("Player took damage from: " + other.name);
            var bombControl = other.GetComponent<BombControl>();
            TakeDamage(bombControl.Damage);
            bombControl.Explode();
        }
        else if (other.CompareTag("Enemy"))
        {
            // Debug.Log("Player took damage from: " + other.name);
            TakeDamage(other.GetComponent<Enemy>().Damage);
        }
    }
}
