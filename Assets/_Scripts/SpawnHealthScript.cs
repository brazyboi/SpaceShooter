using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHealthScript : GameBase
{
    public GameObject health;
    public int xPos;
    public float waitTime = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        base.init();
        StartCoroutine(powerupSpawn());
    }

    IEnumerator powerupSpawn()
    {
        while (manager.running)
        {
            yield return new WaitForSeconds(waitTime);
            xPos = UnityEngine.Random.Range(-Screen.width / 100 + 1, Screen.width / 100 - 1);

            Instantiate(health, new Vector3(xPos, 7, 0), Quaternion.identity);
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            manager.hp = manager.hp + 5;
            Destroy(gameObject);
        }    
    }
}
