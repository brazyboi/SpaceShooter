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
    public Boolean running = true;

    public GameObject playerPrefab;
    public GameObject gameOverPrefab;
    public GameObject menuPrefab;
    public GameObject inGamePrefab;

    AudioSource deathEffect;

    private GameObject inGame;

    // Start is before the first frame update
    void Start()
    {
        gameStart();
        deathEffect = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void gameOver()
    {
        deathEffect.Play(0);
        running = false;
        Instantiate(gameOverPrefab);
        Destroy(inGame);
        var arr = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Enemy").Length; i++)
        {
            Destroy(arr[i]);
        }

        Destroy(GameObject.FindGameObjectWithTag("PowerUp"));
    }

    public void startMenu()
    {
        Instantiate(menuPrefab);
    }

    public void gameStart()
    {

        running = true;
        inGame = Instantiate(inGamePrefab);
        hp = 30;
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
