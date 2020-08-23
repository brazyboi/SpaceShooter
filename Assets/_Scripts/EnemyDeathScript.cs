using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDeathScript : GameBase
{
    public GameObject explosion;
    public GameObject hitEffectBullet;
    public GameObject hitEffectMissile;

    public Transform plane;
    public int enemyHealth;

    void Start()
    {
        base.init();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Instantiate(hitEffectBullet, gameObject.transform.position, Quaternion.identity);
            enemyHealth--;

            if (enemyHealth < 1)
            {
                if (gameObject.tag == "Boss")
                {
                    manager.score = manager.score + 9;
                }
                manager.score++;
                enemyDeath();
            }

            Destroy(collision.gameObject);

        }

        if (collision.gameObject.tag == "Missile")
        {
            Instantiate(hitEffectMissile, gameObject.transform.position, Quaternion.identity);
            enemyHealth = enemyHealth - 3;
            if (enemyHealth < 1)
            {
                if (gameObject.tag == "Boss")
                {
                    manager.score = manager.score + 9;
                }
                manager.score++;
                enemyDeath();
            }

            Destroy(collision.gameObject);

        }

        if (collision.gameObject.tag == "Player")
        {
            enemyHealth = enemyHealth - 5;

            if (enemyHealth < 1)
            {
                if (gameObject.tag == "Boss")
                {
                    manager.score = manager.score + 9;
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
