using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDeathScript : MonoBehaviour
{
    public GameObject explosion;
    public Transform plane;
    public int enemyHealth;

    public Canvas scoreCanvas;
    Transform scoreDisplay;
    Text scoreText;
    public int score = 0;

    void Start()
    {
        scoreCanvas = GetComponent<Canvas>();
        scoreDisplay = scoreCanvas.transform.Find("Score");
        scoreText = scoreDisplay.GetComponent<Text>();
    }

    void Update()
    {
        scoreText.text = "Score: " + score;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            enemyHealth--;
           
            if (enemyHealth <1)
            {
                score++;
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
