﻿using System;
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

    // Start is before the first frame update
    void Start()
    {
        Instantiate(inGamePrefab);
        Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void gameOver()
    {
        running = false;
        Instantiate(gameOverPrefab);
    }

    public void startMenu()
    {
        Instantiate(menuPrefab);
    }

    public void gameStart()
    {
        Instantiate(inGamePrefab);
    }

    public void onPlayerDeath()
    {
        if (numOfPlanes < 1)
        {
            gameOver();
        }
        else
        {
            //destroy current player
            //create a new plane
            createPlayer();
        }


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
