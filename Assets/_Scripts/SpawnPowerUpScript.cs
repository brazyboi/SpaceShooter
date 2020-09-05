using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUpScript : GameBase
{

    public GameObject powerup;
    public int xPos;
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
        while (manager.running)
        {
            yield return new WaitForSeconds(waitTime);
            xPos = UnityEngine.Random.Range(-Screen.width / 100 + 1, Screen.width / 100-1);

            Instantiate(powerup, new Vector3(xPos, 7, 0), Quaternion.identity);
        }

    }

}
