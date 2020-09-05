using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : GameBase
{
    Boolean spawning = false;
    public GameObject enemySpawn;
    public GameObject enemyWaveSpawn;
    public GameObject powerupSpawn;
    public GameObject planetSpawn;

    // Start is called before the first frame update
    void Start()
    {
        base.init();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.running)
        {
            spawning = true;
            if (manager.counter < 1)
            {
                StartCoroutine(startSpawnEnemy());
                manager.counter++;
            }
        } else
        {
            spawning = false;
        }
    }
    
    IEnumerator startSpawnEnemy()
    {
        while (true)
        {
            if (spawning)
            {
                Instantiate(enemySpawn, new Vector3(10, 10, 0), Quaternion.identity);
                Instantiate(enemyWaveSpawn, new Vector3(-10, -10, 0), Quaternion.identity);
                Instantiate(powerupSpawn, new Vector3(10, -10, 0), Quaternion.identity);
                Instantiate(planetSpawn, new Vector3(-10, 10, 0), Quaternion.identity);
                break;
            }

            yield return new WaitForSeconds(0.1f);

        }
    }

}
