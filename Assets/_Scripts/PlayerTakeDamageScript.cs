using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDamageScript : MonoBehaviour
{

    public int playerHealth;
    public Transform plane;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BulletEnemy")
        {
            playerHealth--;

            if (playerHealth < 1)
            {
                playerDeath();
            }

            Destroy(collision.gameObject);

        }
    }

    void playerDeath()
    {
        GetComponent<Collider>().enabled = false;
        Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject); 
    }
}
