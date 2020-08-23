using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyAimedScript : MonoBehaviour
{
    public float speed;
    GameObject player;
    Vector3 playerPos;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        playerPos = (player.transform.position - gameObject.transform.position).normalized;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = gameObject.transform.position;
        pos = pos + playerPos * Time.deltaTime * speed;
        gameObject.transform.position = pos;

        Vector3 screenPos = cam.WorldToScreenPoint(gameObject.transform.position);
        if (screenPos.y < 0)
        {
            Destroy(gameObject);
        }


    }
}
