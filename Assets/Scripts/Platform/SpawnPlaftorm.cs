using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnPlaftorm : MonoBehaviour
{

    [SerializeField] private List<GameObject> platforms = new(); // Platform prefabs
    
    private float platformXPos;
    private List<Transform> currentPlatforms = new(); // Platform clones instantiated
    private Transform player;

    private Transform currentPlatformPoint;
    private int platformIndex;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        for (var i = 0; i < platforms.Count; i++)
        {
            Transform platformClone = Instantiate(platforms[i], new Vector2(i * 30, -4), transform.rotation).transform;
            platformXPos += 30;
            currentPlatforms.Add(platformClone);
        }
        
        currentPlatformPoint = currentPlatforms[platformIndex].GetComponent<PlatformControl>().finalPoint;
        
        // Debug.Log("Current platform: " + currentPlatformPoint.name + " / Final point posX: " + currentPlatformPoint.position.x);
    }

    void Update()
    {
        Move();
    }
    
    void Move()
    {
        
        float distance = player.position.x - currentPlatformPoint.position.x;
        // Debug.Log("Distancia entre o player e o final da plataforma: " + distance + " / Player posX: " + player.position.x);
        if (distance >= 1)
        {
            // Debug.Log("Player chegou no final da plataforma");
            Recycle(currentPlatforms[platformIndex].GameObject());
            platformIndex++;
            if (platformIndex > currentPlatforms.Count - 1)
            {
                platformIndex = 0;
            }
            currentPlatformPoint = currentPlatforms[platformIndex].GetComponent<PlatformControl>().finalPoint;
        }
    }

    private void Recycle(GameObject platform)
    {
        platform.transform.position = new Vector2(platformXPos, -4.5f);
        platformXPos += 30;

        var platformControl = platform.GetComponent<PlatformControl>();
        if (platformControl.enemiesSpawner)
        {
            platformControl.enemiesSpawner.SpawnNewEnemy();
        }
    }
    
}
