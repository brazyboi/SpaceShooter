using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUpScript : MonoBehaviour
{

    public GameObject powerup;
    public int xPos;
    public float waitTime = 5.0f;

    Boolean running = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(powerupSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator powerupSpawn()
    {
        while (running)
        {
            yield return new WaitForSeconds(waitTime);
            xPos = UnityEngine.Random.Range(-Screen.width / 100, Screen.width / 100);

            Instantiate(powerup, new Vector3(xPos, 7, 0), Quaternion.identity);
        }

    }

}
