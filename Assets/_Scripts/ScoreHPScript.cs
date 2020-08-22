using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHPScript : GameBase
{
    public Text scoreText;
    public Text hpText;
    // Start is called before the first frame update
    void Start()
    {
        base.init();
    }

    // Update is called once per frame
    void Update()
    {
        hpText.text = "HP: " + manager.hp;
        scoreText.text = "Score: " + manager.score;
    }
}
