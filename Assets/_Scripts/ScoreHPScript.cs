using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHPScript : GameBase
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI bossIncoming;
    public TextMeshProUGUI bossHpText;

    // Start is called before the first frame update
    void Start()
    {
        base.init();
        bossIncoming.enabled = false;
        StartCoroutine(incomingText());
    }

    // Update is called once per frame
    void Update()
    {
        hpText.text = "HP:" + manager.hp;
        scoreText.text = "Score:" + manager.score * 100;

        GameObject boss = GameObject.FindGameObjectWithTag("Boss");
        if (boss == null)
        {
            bossHpText.enabled = false;
            manager.running = true;
        }
        else
        {
            bossHpText.enabled = true;
            manager.running = false;
            bossHpText.text = "Boss HP:" + manager.bossHP;
        }

    }
    
    IEnumerator incomingText()
    {
        while (manager.running)
        {
            yield return new WaitForSeconds(55);
            bossIncoming.enabled = true;

            yield return new WaitForSeconds(5);

            bossIncoming.enabled = false;
        }
    }
}
