using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGameScript : MonoBehaviour
{
    public Button pause;
    int numOfClicks = 0;

    // Start is called before the first frame update
    void Start()
    {
        pause.onClick.AddListener(pauseGame);
    }

    void pauseGame()
    {
        numOfClicks++;
        if (numOfClicks%2 == 1)
        {
            Time.timeScale = 0;
        } else
        {
            Time.timeScale = 1;
        }
        
    }
}
