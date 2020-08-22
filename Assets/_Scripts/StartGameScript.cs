using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameScript : GameBase
{
    public Button start;
    // Start is called before the first frame update
    void Start()
    {
        base.init();
        start.onClick.AddListener(startGame);
    }

    void startGame()
    {
        Destroy(gameObject);
        manager.gameStart();
    }
}
