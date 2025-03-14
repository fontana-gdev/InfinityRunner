using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BombEnemy : Enemy
{

    [SerializeField] GameObject bombPrefab;
    [SerializeField] private float shootRate;
    [SerializeField] private Transform bombPosition;

    private float shootTimer;

    private void Start()
    {
        Instantiate(bombPrefab, bombPosition.position, bombPosition.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer > shootRate)
        {
            Instantiate(bombPrefab, bombPosition.position, bombPosition.rotation);
            shootTimer = 0;
        }
    }

}
