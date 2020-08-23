using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemyScript : GameBase
{
    public GameObject enemy;
    float xPos;
    public float waitTime = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        base.init();
        StartCoroutine(enemySpawn());
    }

    IEnumerator enemySpawn()
    {
        while (manager.running)
        {
            xPos = UnityEngine.Random.Range(-Screen.width + 100, Screen.width - 100)/100;
            
            Instantiate(enemy, new Vector3(xPos, 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(waitTime);


        }
    }

}
