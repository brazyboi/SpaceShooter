using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUpScript : GameBase
{

    public GameObject powerup;
    public float xPos;
    public float waitTime = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        base.init();
        StartCoroutine(powerupSpawn());
    }

    // Update is called once per frame
    void Update()   
    {
        
    }

    IEnumerator powerupSpawn()
    {
        while (true)
        {
            if (manager.running)
            {
                yield return new WaitForSeconds(waitTime);
                xPos = UnityEngine.Random.Range(-Screen.width + 200, Screen.width - 200) / 100;

                Instantiate(powerup, new Vector3(xPos, 7, 0), Quaternion.identity);
            } else
            {
                yield return new WaitForSeconds(0.1f);
            }
            
        }

    }

}
