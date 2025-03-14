using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallControl : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.ShowGameOver();
        }
    }
}
