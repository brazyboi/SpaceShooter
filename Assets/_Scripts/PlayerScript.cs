using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float fireRate = 0.3f;
    public GameObject playerBullet;
    Boolean firing = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fire());
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        //Get the value of the Horizontal input axis.

        float verticalInput = Input.GetAxis("Vertical");
        //Get the value of the Vertical input axis.

        transform.Translate(new Vector3(horizontalInput, 0, verticalInput) * moveSpeed * Time.deltaTime);
        //Move the object to XYZ coordinates defined as horizontalInput, 0, and verticalInput respectively.

    }

    IEnumerator Fire()
    {

        while (firing)
        {
            Instantiate(playerBullet, gameObject.transform.position, Quaternion.identity);
            playerBullet.transform.position = gameObject.transform.position;

            yield return new WaitForSeconds(fireRate);

        }
    }

}
