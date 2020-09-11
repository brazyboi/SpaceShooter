using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMoveScript : GameBase
{
    Boolean firing = true;
    public GameObject enemyBullet;
    public float fireRate = 1f;
    public float speed = -1f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        base.init();
        rb = GetComponent<Rigidbody>();
        StartCoroutine(Fire());
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = gameObject.transform.position;

        pos.y = pos.y + Time.deltaTime * speed;
        gameObject.transform.position = pos;

        if (pos.y < 4)
        {
            speed = 0f;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = (mousePosition - transform.position).normalized;

            rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

        if (manager.numOfBosses == 2)
        {
            fireRate = 0.8f;
        }

        if (manager.numOfBosses == 4)
        {
            fireRate = 0.7f;
        }

        if (manager.numOfBosses == 5)
        {
            fireRate = 0.6f;
        }

    }

    IEnumerator Fire()
    {

        while (firing)
        {

            Instantiate(enemyBullet, gameObject.transform.position, Quaternion.identity);
            enemyBullet.transform.position = gameObject.transform.position;

            yield return new WaitForSeconds(fireRate);

        }
    }

}
