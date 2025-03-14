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
        // Can be used on Update, because that's just one time event each key press
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
            animator.SetBool("jumping", true);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletPrefab, shotPoint.position, shotPoint.rotation);
        }
    }

    // Update is called once per frame
    void FixedUpdate() 
    {
        rig.velocity = new Vector2(playerSpeed, rig.velocity.y);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
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
            TakeDamage(other.GetComponent<BombControl>().Damage);
        }
        else if (other.CompareTag("Enemy"))
        {
            TakeDamage(other.GetComponent<Enemy>().Damage);
        }
    }
}
