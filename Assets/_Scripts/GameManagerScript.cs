using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public int score = 0;
    public int hp = 10;
    public int numOfPlanes;
    public int counter = 0;
    public Boolean running = true;
    public int numOfPowerUps = 0;

    public float waitTime = 4.0f;
    public float numOfBosses = 0;

    public GameObject playerPrefab;
    public GameObject gameOverPrefab;
    public GameObject menuPrefab;
    public GameObject inGamePrefab;

    AudioSource deathEffect;

    private GameObject inGame;

    // Start is before the first frame update
    void Start()
    {
        startMenu();
        
        deathEffect = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void destroyEverything()
    {
        var arrayEnemy = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < arrayEnemy.Length; i++)
        {
            Destroy(arrayEnemy[i]);
        }

        var arrayPowerUp = GameObject.FindGameObjectsWithTag("PowerUp");

        for (int i = 0; i < arrayPowerUp.Length; i++)
        {
            Destroy(arrayPowerUp[i]);
        }

        var arrayBulletEnemy = GameObject.FindGameObjectsWithTag("BulletEnemy");

        for (int i = 0; i < arrayBulletEnemy.Length; i++)
        {
            Destroy(arrayBulletEnemy[i]);
        }

        var arrayBulletBoss = GameObject.FindGameObjectsWithTag("BulletBoss");

        for (int i = 0; i < arrayBulletBoss.Length; i++)
        {
            Destroy(arrayBulletBoss[i]);
        }

        var arraySpawners = GameObject.FindGameObjectsWithTag("Spawn");

        for (int i = 0; i < arraySpawners.Length; i++)
        {
            Destroy(arraySpawners[i]);
        }

        Destroy(GameObject.FindGameObjectWithTag("Boss"));
    }

    void gameOver()
    {
        deathEffect.Play(0);
        running = false;
        Instantiate(gameOverPrefab);
        Destroy(inGame);

        destroyEverything();
        numOfPowerUps = 0;
    }

    public void startMenu()
    {
        Instantiate(menuPrefab);
    }

    public void gameStart()
    {
        counter = 0;
        waitTime = 4.0f;

        destroyEverything();

        inGame = Instantiate(inGamePrefab);
        running = true; 
        hp = 100;
        score = 0;
        Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }
    public void onPlayerDeath()
    {
        /* (numOfPlanes < 1)
        {
            gameOver();
        }
        else
        {
            //destroy current player
            //create a new plane
            createPlayer();
        }*/

        gameOver();

    }

    public void getBomb()
    {

    }

    void createPlayer()
    {

        numOfPlanes--;

        Instantiate(playerPrefab, new Vector3(0,0,0), Quaternion.identity);
    }

}
