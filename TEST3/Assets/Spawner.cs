using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject[] enemy;
    public float timeBetweenSpawn;
    [SerializeField] private float startTimeBetweenSpawn = 2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBetweenSpawn <= 0)
        {
            SpawnEnemy();
            timeBetweenSpawn = startTimeBetweenSpawn;
        }
        else
        {
            timeBetweenSpawn -= Time.deltaTime;
        }
    }

    void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform SpawnPoint = spawnPoints[randomIndex];
        int randomEnemy = Random.Range(0, enemy.Length);
        Instantiate(enemy[randomEnemy], SpawnPoint.position, Quaternion.identity);

    }
}
