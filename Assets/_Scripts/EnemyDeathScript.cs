using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDeathScript : GameBase
{
    public GameObject explosion;
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
            enemyHealth--;

            if (enemyHealth < 1)
            {
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
