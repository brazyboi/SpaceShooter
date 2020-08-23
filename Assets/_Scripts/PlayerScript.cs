using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using UnityEngine;

public class PlayerScript : GameBase
{
    public float moveSpeed = 10.0f;
    public float fireRate = 1.0f;
    public float missileFireRate = 1.0f;
    public int numOfPowerUps = 0;
    public int numOfBombs = 0;
    int numOfMissiles = 0;

    public GameObject leftgun;
    public GameObject rightgun;
    public GameObject centerGun;
    public GameObject playerBullet;
    public GameObject missile;
    public GameObject explosion;

    public Transform plane;
  
    Boolean firing = true;

    // Start is called before the first frame update
    void Start()
    {
        base.init();
        StartCoroutine(Fire());
        StartCoroutine(fireMissile());
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        //Get the value of the Horizontal input axis.

        float verticalInput = Input.GetAxis("Vertical");
        //Get the value of the Vertical input axis.

        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime);
        //Move the object to XYZ coordinates defined as horizontalInput, 0, and verticalInput respectively.

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PowerUp")
        {
            numOfPowerUps++;
            Destroy(collision.gameObject);

        }

        if (collision.gameObject.tag == "BulletEnemy")
        {
            manager.hp--;

            if (manager.hp < 1)
            {
                playerDeath();
            }

            Destroy(collision.gameObject);

        }

        if (collision.gameObject.tag == "Enemy")
        {
            manager.hp = manager.hp - 5;

            if (manager.hp < 1)
            {
                playerDeath();
            }

            Destroy(collision.gameObject);

        }

    }

    void playerDeath()
    {
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

            switch (numOfPowerUps)
            {
                case 0:
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
                    break; 
                case 6:
                    waitTime = fireRate / 4;
                    numOfGuns = 3;
                    numOfMissiles = 1;
                    break;
                case 7:
                    waitTime = fireRate / 4;
                    numOfGuns = 3;
                    numOfMissiles = 2;
                    break;
                default:
                    waitTime = fireRate / 6;
                    numOfGuns = 3;
                    numOfMissiles = 2;
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

            } else {
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
            } else if (numOfMissiles == 2)
            {
                Instantiate(missile, leftgun.transform.position, Quaternion.identity);
                Instantiate(missile, rightgun.transform.position, Quaternion.identity);
            } 
            yield return new WaitForSeconds(missileFireRate);
        }
    }

}
