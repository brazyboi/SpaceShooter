using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadBulletScript : GameBase
{
    public float speed;
    Vector3 spreadPos;

    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        base.init();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        manager.spreadCount++;
        if (manager.spreadCount > 10)
        {
            manager.spreadCount = 0;
        }

        spreadPos = new Vector3(10 - manager.spreadCount * 2, -3, 0) - gameObject.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = gameObject.transform.position;

        pos = pos + spreadPos * Time.deltaTime * speed;
        gameObject.transform.position = pos;

        Vector3 screenPos = cam.WorldToScreenPoint(gameObject.transform.position);

        if (screenPos.y < 0)
        {
            Destroy(gameObject);
        }
    }

}
