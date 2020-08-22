using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public int score = 0;
    public int numOfPlanes;
    public GameObject playerPrefab;
    public GameObject gameOverPrefab;
    
    // Start is before the first frame update
    void Start()
    {
        Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void gameOver()
    {
        Instantiate(gameOverPrefab);
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
