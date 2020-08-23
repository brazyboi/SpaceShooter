using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyAimedScript : MonoBehaviour
{
    public float speed;
    GameObject player;
    Vector3 playerPos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerPos = (player.transform.position - gameObject.transform.position).normalized;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = gameObject.transform.position;
        pos = pos + playerPos * Time.deltaTime * speed;
        gameObject.transform.position = pos;
        
    }
}
