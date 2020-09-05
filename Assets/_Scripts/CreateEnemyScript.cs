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
    int count = 0;
    
    public float bossWaitTime = 30.0f;

    // Start is called before the first frame update
    void Start()
    {
        base.init();
        StartCoroutine(enemySpawn());
        StartCoroutine(bossSpawn());
    }

    private void Update()
    {
        if (manager.waitTime > 1.5f && count < manager.numOfBosses)
        {
            manager.waitTime -= (manager.numOfBosses * 0.5f);
            if (count < 5)
            {
                count++;
            }
            
        }
    }

    IEnumerator enemySpawn()
    {
        while (manager.running)
        {
            yield return new WaitForSeconds(manager.waitTime);   

            if (!manager.running)
            {
                break;
            }
            xPos = UnityEngine.Random.Range(-Screen.width + 150, Screen.width - 150)/100;

            GameObject enemy;

            if (UnityEngine.Random.Range(1, 4) == 1)
            {
                enemy = enemy3;
            } else if (UnityEngine.Random.Range(1, 4) == 2)
            {
                enemy = enemy2;
            } else
            {
                enemy = enemy1;
            }

            Instantiate(enemy, new Vector3(xPos, 7, 0), Quaternion.identity);

            
        }
    }

    IEnumerator bossSpawn()
    {
        while (manager.running)
        {
            if (!manager.running)
            {
                break;
            }
            yield return new WaitForSeconds(bossWaitTime);
            manager.numOfBosses++;
            Instantiate(boss, new Vector3(0, 7.5f, 0), Quaternion.identity);
              

        }
    }

}
