using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speedX = 0;
    public float speedY = 3.0f;
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
        pos.x = pos.x + Time.deltaTime * speedX;
        pos.y = pos.y + Time.deltaTime * speedY;
        gameObject.transform.position = pos;

        Vector3 screenPos = cam.WorldToScreenPoint(gameObject.transform.position);
        if (screenPos.y > Screen.height)
        {
            Destroy(gameObject);
        }
        
    }


}
