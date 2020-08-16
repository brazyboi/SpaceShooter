using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathScript : MonoBehaviour
{
    AudioSource enemyDeath;

    void Start()
    {
        enemyDeath = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (!enemyDeath.isPlaying)
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }

        }
    }
}
