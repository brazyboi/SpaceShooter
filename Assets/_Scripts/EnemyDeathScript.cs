using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathScript : MonoBehaviour
{
    public GameObject explosion;
    public Transform plane;
    public int enemyHealth;

    void Start()
    {
    
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            enemyHealth--;
           
            if (enemyHealth <1)
            {
                enemyDeath();
            }

            Destroy(collision.gameObject);  

        }

    }

    void enemyDeath()
    {
        GetComponent<Collider>().enabled = false;
        Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
 

    }


}
