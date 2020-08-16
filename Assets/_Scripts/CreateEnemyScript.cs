using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemyScript : MonoBehaviour
{
    public GameObject enemy;
    public int xPos;
    public int enemyCount;
    private float waitTime = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(enemySpawn());
    }

    IEnumerator enemySpawn()
    {
        while (enemyCount < 4)
        {
            xPos = Random.Range(-Screen.width/100, Screen.width/100);

            Instantiate(enemy, new Vector3(xPos, 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(waitTime);
            enemyCount += 1;

        }
    }

}
