using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthMoveDownScript : MonoBehaviour
{
    public float speed = 1.0f;

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

        pos.y = pos.y + Time.deltaTime * speed;
        gameObject.transform.position = pos;

        if (screenPos.y < 0)
        {
            Destroy(gameObject);
        }
    }
}
