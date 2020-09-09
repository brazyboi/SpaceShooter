using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossDeathScript : GameBase
{
    public GameObject explosion;
    public GameObject hitEffectBullet;
    public GameObject hitEffectMissile;

    public Transform plane;

    void Start()
    {
        base.init();
        manager.bossHP = (int)(manager.bossHP + manager.numOfBosses * 150);
        
    }

    void Update()
    {


    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Instantiate(hitEffectBullet, gameObject.transform.position, Quaternion.identity);
            manager.bossHP = manager.bossHP - 2;

            if (manager.bossHP < 1)
            {
                if (gameObject.tag == "Boss")
                {
                    manager.score = manager.score + 29;
                }
                manager.score++;
                enemyDeath();
            }

            Destroy(collision.gameObject);

        }

        if (collision.gameObject.tag == "Missile")
        {
            Instantiate(hitEffectMissile, gameObject.transform.position, Quaternion.identity);
            manager.bossHP = manager.bossHP - 4;
            if (manager.bossHP < 1)
            {
                if (gameObject.tag == "Boss")
                {
                    manager.score = manager.score + 49;
                }
                manager.score++;
                enemyDeath();
            }

            Destroy(collision.gameObject);

        }

        if (collision.gameObject.tag == "Player")
        {
            manager.bossHP = manager.bossHP - 20;

            if (manager.bossHP < 1)
            {
                if (gameObject.tag == "Boss")
                {
                    manager.score = manager.score + 29;
                }
                manager.score++;
                enemyDeath();
            }

        }

    }

    void enemyDeath()
    {
        GetComponent<Collider>().enabled = false;
        Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);

    }


}
