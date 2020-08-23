using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemyScript : GameBase
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject boss;

    float xPos;
    public float waitTime = 3.0f;
    public float bossWaitTime = 30.0f;

    // Start is called before the first frame update
    void Start()
    {
        base.init();
        StartCoroutine(enemySpawn());
        StartCoroutine(bossSpawn());
    }

    IEnumerator enemySpawn()
    {
        while (manager.running)
        {
            xPos = UnityEngine.Random.Range(-Screen.width + 100, Screen.width - 100)/100;

            GameObject enemy;

            if (UnityEngine.Random.Range(1, 3) == 1)
            {
                enemy = enemy1;
            } else if (UnityEngine.Random.Range(1, 3) == 2)
            {
                enemy = enemy2;
            } else
            {
                enemy = enemy3;
            }

            Instantiate(enemy, new Vector3(xPos, 7, 0), Quaternion.identity);

            yield return new WaitForSeconds(waitTime);


        }
    }

    IEnumerator bossSpawn()
    {
        while (manager.running)
        {
            yield return new WaitForSeconds(bossWaitTime);
            if (!manager.running)
            {
                break;
            }
            Instantiate(boss, new Vector3(0, 7, 0), Quaternion.identity);   
        }
    }

}
