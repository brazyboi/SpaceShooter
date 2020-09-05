using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScript : MonoBehaviour
{
    public float speed = -0.5f;
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

        if (screenPos.y < -50)
        {
            Destroy(gameObject);
        }
    }
}
