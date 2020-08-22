using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDeathScript : MonoBehaviour
{
    public GameObject explosion;
    public Transform plane;
    public int enemyHealth;

    public int score = 0;

    void Start()
    {
    }

    void Update()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            enemyHealth--;

            if (enemyHealth < 1)
            {
                score++;
                enemyDeath();
            }

            Destroy(collision.gameObject);

        }

        if (collision.gameObject.tag == "Player")
        {
            enemyHealth = enemyHealth - 5;

            if (enemyHealth < 1)
            {
                score++;
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
