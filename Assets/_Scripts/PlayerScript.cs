﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : GameBase
{
    public float moveSpeed = 10.0f;
    public float fireRate = 1.0f;
    public float missileFireRate = 1.0f;
    public int numOfBombs = 0;
    int numOfMissiles = 0;

    public GameObject leftgun;
    public GameObject rightgun;
    public GameObject centerGun;
    public GameObject playerBullet;
    public GameObject missile;
    public GameObject explosion;
    public GameObject hitEffect;
    public GameObject hitEffect1;
    GameObject miniPlane1;
    GameObject miniPlane2;

    public Transform plane;

    Boolean firing = true;

    // Start is called before the first frame update
    void Start()
    {
        base.init();

        StartCoroutine(Fire());
        StartCoroutine(fireMissile());

        miniPlane1 = GameObject.FindGameObjectWithTag("PlayerMini1");
        miniPlane1.SetActive(false);
        miniPlane2 = GameObject.FindGameObjectWithTag("PlayerMini2");
        miniPlane2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = gameObject.transform.position;

        float horizontalInput = Input.GetAxis("Horizontal");
        //Get the value of the Horizontal input axis.

        float verticalInput = Input.GetAxis("Vertical");
        //Get the value of the Vertical input axis.

        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime);
        //Move the object to XYZ coordinates defined as horizontalInput, 0, and verticalInput respectively.

        if (manager.numOfPlanes == 2)
        {
            miniPlane1.SetActive(true);
            miniPlane2.SetActive(false);
        }
        else if (manager.numOfPlanes == 3)
        {
            miniPlane1.SetActive(true);
            miniPlane2.SetActive(true);
        }
        else if (manager.numOfPlanes <= 1)
        {
            miniPlane1.SetActive(false);
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PowerUp")
        {
            if (manager.numOfPowerUps < 12)
            {
                manager.numOfPowerUps++;
                print(manager.numOfPowerUps);
            }

            Destroy(collision.gameObject);

        }

        if (collision.gameObject.tag == "BulletEnemy")
        {
            manager.hp = (int)(manager.hp - 1 - manager.numOfBosses);
            Instantiate(hitEffect, gameObject.transform.position, Quaternion.identity);

            if (manager.hp < 1)
            {
                playerDeath();
            }

            Destroy(collision.gameObject);

        }

        if (collision.gameObject.tag == "Enemy")
        {
            manager.hp = (int)(manager.hp - 5 - manager.numOfBosses);

            if (manager.hp < 1)
            {
                playerDeath();
            }

            Destroy(collision.gameObject);

        }

        if (collision.gameObject.tag == "BulletBoss")
        {
            manager.hp = (int)(manager.hp - 3 - manager.numOfBosses);
            Instantiate(hitEffect, gameObject.transform.position, Quaternion.identity);

            if (manager.hp < 1)
            {
                playerDeath();
            }

            Destroy(collision.gameObject);

        }

        if (collision.gameObject.tag == "MissileEnemy")
        {
            manager.hp = (int)(manager.hp - 5 - manager.numOfBosses);
            Instantiate(hitEffect1, gameObject.transform.position, Quaternion.identity);

            if (manager.hp < 1)
            {
                playerDeath();
            }

            Destroy(collision.gameObject);

        }



    }

    void playerDeath()
    {
        manager.numOfPowerUps = 0;

        GameObject playerMini1 = GameObject.FindGameObjectWithTag("PlayerMini1");

        if (playerMini1 != null)
        {
            playerMini1.SetActive(false);
        }

        manager.onPlayerDeath();
        GetComponent<Collider>().enabled = false;
        Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    IEnumerator Fire()
    {

        while (firing)
        {

            float waitTime = fireRate;
            int numOfGuns = 1;

            switch (manager.numOfPowerUps)
            {
                case 0:
                    manager.numOfPlanes = 1;
                    break;
                case 1:
                    waitTime = fireRate / 2;
                    break;
                case 2:
                    waitTime = fireRate / 2;
                    numOfMissiles = 1;
                    break;
                case 3:
                    waitTime = fireRate / 4;
                    numOfMissiles = 1;
                    break;
                case 4:
                    waitTime = fireRate / 4;
                    numOfGuns = 2;
                    numOfMissiles = 1;
                    break;
                case 5:
                    waitTime = fireRate / 6;
                    numOfGuns = 2;
                    numOfMissiles = 1;
                    missileFireRate = 1.5f;
                    break;
                case 6:
                    waitTime = fireRate / 4;
                    numOfGuns = 3;
                    numOfMissiles = 1;
                    missileFireRate = 1.5f;
                    break;
                case 7:
                    waitTime = fireRate / 4;
                    numOfGuns = 3;
                    numOfMissiles = 2;
                    missileFireRate = 1.5f;
                    break;
                case 8:
                    waitTime = fireRate / 5;
                    numOfGuns = 3;
                    numOfMissiles = 2;
                    missileFireRate = 1.5f;
                    break;
                case 9:
                    waitTime = fireRate / 6;
                    numOfGuns = 3;
                    numOfMissiles = 2;
                    missileFireRate = 1f;
                    break;
                case 10:
                    waitTime = fireRate / 6;
                    numOfGuns = 3;
                    numOfMissiles = 2;
                    missileFireRate = 1f;
                    manager.numOfPlanes = 2;
                    break;
                default:
                    waitTime = fireRate / 6;
                    numOfGuns = 3;
                    numOfMissiles = 2;
                    missileFireRate = 1.25f;
                    manager.numOfPlanes = 3;
                    break;
            }

            if (numOfGuns >= 2)
            {
                Instantiate(playerBullet, leftgun.transform.position, Quaternion.identity);
                Instantiate(playerBullet, rightgun.transform.position, Quaternion.identity);

                if (numOfGuns == 3)
                {
                    Instantiate(playerBullet, centerGun.transform.position, Quaternion.identity);
                }

            }
            else
            {
                Instantiate(playerBullet, centerGun.transform.position, Quaternion.identity);

            }

            playerBullet.transform.position = gameObject.transform.position;
            yield return new WaitForSeconds(waitTime);
        }
    }

    IEnumerator fireMissile()
    {
        while (firing)
        {
            if (numOfMissiles == 1)
            {
                Instantiate(missile, centerGun.transform.position, Quaternion.identity);
            }
            else if (numOfMissiles == 2)
            {
                Instantiate(missile, leftgun.transform.position, Quaternion.identity);
                Instantiate(missile, rightgun.transform.position, Quaternion.identity);
            }
            yield return new WaitForSeconds(missileFireRate);
        }
    }

}
