using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombControl : MonoBehaviour
{
    [SerializeField] private float horizontalForce;
    [SerializeField] private float verticalForce;
    [SerializeField] private int damage;
    [SerializeField] private GameObject impactEffect;

    private Rigidbody2D rig;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.AddForce(new Vector2(-horizontalForce, verticalForce), ForceMode2D.Impulse);
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Platform"))
        {
            Explode();
        }
        else if (other.CompareTag("Projectile"))
        {
            other.GetComponent<Projectile>().Explode();
            Explode();
        }
    }

    public void Explode()
    {
        var explosion = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(explosion, 1);
    }

    public int Damage => damage;
}