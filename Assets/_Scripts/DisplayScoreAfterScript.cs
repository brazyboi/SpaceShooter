using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScoreAfterScript : GameBase
{
    public Text scoreAfter;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        base.init();
    }

    // Update is called once per frame
    void Update()
    {
        score = manager.score * 100;
        scoreAfter.text = "Score is: " + score.ToString();
        print(score);
    }
}
