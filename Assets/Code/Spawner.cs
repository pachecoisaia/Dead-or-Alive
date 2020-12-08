using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    float nextSpawnTime = 0f;
    public float spawnDelay = 1.0f;
    public Transform[] sP;
    public GameObject zombie;
    
    void Update() {

        if  (nextSpawnTime <= Time.time)
        {
            SpawnZombie();
            nextSpawnTime = Time.time + spawnDelay;
        }
    }

    void SpawnZombie() {
        int randomIndex = Random.Range(0,sP.Length);
        Transform spawnPoint = sP[randomIndex];
        Instantiate(zombie, spawnPoint.position,spawnPoint.rotation);
    }
}