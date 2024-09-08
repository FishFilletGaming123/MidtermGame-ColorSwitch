using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject Enemies;
    public float spawnDelay = 5f;

    void Start()
    {
        InvokeRepeating("SpawnEnemies", 0f, spawnDelay);
    }

    void SpawnEnemies()
    {
        if (spawnPoints.Length == 0 || Enemies == null)
        {
            return;
        }

        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform randomPos = spawnPoints[randomIndex];
        Instantiate(Enemies, randomPos.position, randomPos.rotation);
    }
}
