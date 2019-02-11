using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private SpawnPoints spawnPoints;
    public float timeBetweenSpawn;
    private float nextSpawn;
    [SerializeField]
    private GameObject enemyToSpawn;

    public void SpawnWave()
    {
        if (Time.time>=nextSpawn)
        {
            Instantiate(enemyToSpawn,spawnPoints.spawnPoints[Random.Range(0,spawnPoints.spawnPoints.Length)].position,Quaternion.identity);
            nextSpawn = Time.time + timeBetweenSpawn;
        }
    }

}
