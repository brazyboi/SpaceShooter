using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : GameBase
{
    public float speed = 1.0f;
    public float fireRate = 0.5f;

    int direction = 1;
    Boolean firing = true;
    Camera cam;
    public GameObject enemyBullet;

    // Start is called before the first frame update
    void Start()
    {
        base.init();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        StartCoroutine(Fire());
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

        if (screenPos.x > Screen.width || screenPos.x < -Screen.width)
        {
            firing = false;
        }

    }

    IEnumerator Fire()
    {

        while (firing)  
        {
            if (!this.gameObject.activeSelf)
            {
                break;
            }

            Instantiate(enemyBullet, gameObject.transform.position, Quaternion.identity);
            enemyBullet.transform.position = gameObject.transform.position;

            if (gameObject.tag != "Boss")
            {
                fireRate = fireRate + 1 / (manager.numOfBosses + 1);
            }

            yield return new WaitForSeconds(fireRate);

        }
    }

    void OnDestroy()
    {
        StopCoroutine(Fire());    
    }

}