using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    [SerializeField] float projectileSpeed;
    [SerializeField] int damage;
    [SerializeField] GameObject impactEffect;

    public int Damage => damage;

    private Rigidbody2D rig;
    
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rig.velocity = Vector2.right * projectileSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Platform"))
        {
            Explode();
        }
    }

    public void Explode()
    {
        var explosion = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(explosion, 1);
    }
    
}
