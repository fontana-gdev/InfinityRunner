using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatformEnemies : MonoBehaviour
{

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private List<Transform> spawnPoints;
    
    private GameObject currentEnemy;
    
    // Start is called before the first frame update
    void Start()
    {
        CreateEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnNewEnemy()
    {
        if (!currentEnemy)
        {
            CreateEnemy();
        }
    }

    private void CreateEnemy()
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
        currentEnemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
    
}
