using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    
    public List<GameObject> enemiesList = new();
    [SerializeField] private float spawnRate;
    
    private float spawnTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnRate)
        {
            SpawnEnemy();
            spawnTimer = 0;
        }
    }

    void SpawnEnemy()
    {
        int enemyIndex = Random.Range(0, enemiesList.Count);
        var spawnPosition = transform.position + new Vector3(0, Random.Range(-1, 2), 0);
        Instantiate(enemiesList[enemyIndex], spawnPosition, transform.rotation);
    }
    
}
