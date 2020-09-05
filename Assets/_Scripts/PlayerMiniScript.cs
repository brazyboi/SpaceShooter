using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMiniScript : GameBase
{
    public float fireRate = 0.5f;

    public GameObject explosion;
    public GameObject hitEffect;
    public GameObject hitEffect1;
    public GameObject bullet;

    Boolean firing = true;

    // Start is called before the first frame update
    void Start()
    {
        base.init();
        manager.hp = manager.hp + 25;
        StartCoroutine(Fire());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
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
        gameObject.SetActive(false);
        GetComponent<Collider>().enabled = false;
        Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
    }

    IEnumerator Fire()
    {
        while (firing)
        {
            Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(fireRate);
        }
    }

}
