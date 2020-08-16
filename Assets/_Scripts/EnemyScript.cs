using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed = 1.0f;
    int direction = 1;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = gameObject.transform.position;
        Vector3 screenPos = cam.WorldToScreenPoint(gameObject.transform.position);

        /*if (screenPos.x > Screen.width)
        {
            direction = -1;
        } else if(screenPos.x < 0)
        {
            direction = 1;
        }

        pos.x = pos.x + Time.deltaTime * speed * direction;
        gameObject.transform.position = pos;*/

        pos.y = pos.y + Time.deltaTime * speed * direction;
        gameObject.transform.position = pos;

        if (screenPos.y < 0)
        {
            Destroy(gameObject);
        }

    }   

}