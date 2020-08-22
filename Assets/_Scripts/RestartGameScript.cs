using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartGameScript : GameBase
{
    public Button restart;

    // Start is called before the first frame update
    void Start()
    {
        base.init();
        restart.onClick.AddListener(restartGame);
    }

    void restartGame()
    {
        Destroy(gameObject);
        manager.startMenu();
    }

}
