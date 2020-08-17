using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float fireRate = 1.0f;
    public int numOfPowerUps = 0;

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

        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime);
        //Move the object to XYZ coordinates defined as horizontalInput, 0, and verticalInput respectively.

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PowerUp")
        {
            numOfPowerUps++;
            Destroy(collision.gameObject);

        }
    }

    IEnumerator Fire()
    {

        while (firing)
        {
            Vector3 pos = gameObject.transform.position;

            if (numOfPowerUps == 1)
            {
                yield return new WaitForSeconds(fireRate / 2);
            }
            else if (numOfPowerUps ==2)
            {
                yield return new WaitForSeconds(fireRate / 4);
            }
            else if (numOfPowerUps > 2)
            {
                pos.x = gameObject.transform.position.x + 1;
                Vector3 doublePos = new Vector3();
                doublePos.x = gameObject.transform.position.x - 1;


                Instantiate(playerBullet, doublePos, Quaternion.identity);
            }
            else
            {
                yield return new WaitForSeconds(fireRate);
            }

            Instantiate(playerBullet, gameObject.transform.position, Quaternion.identity);
            playerBullet.transform.position = gameObject.transform.position;

        }
    }

}
