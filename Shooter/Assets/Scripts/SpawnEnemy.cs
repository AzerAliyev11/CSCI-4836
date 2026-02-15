using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    private float spawnCooldown = 5f;
    private float timeToSpawn = 0f;

    void Update()
    {
        if(timeToSpawn == 0f)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
        }

        timeToSpawn += Time.deltaTime;
        if(timeToSpawn >= spawnCooldown)
        {
            timeToSpawn = 0f;
        }
    }
}
