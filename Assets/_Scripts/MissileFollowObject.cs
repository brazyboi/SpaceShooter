using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ? 2017 TheFlyingKeyboard and released under MIT License
// theflyingkeyboard.net
public class MissileFollowObject : MonoBehaviour
{
    public GameObject target;
    public float moveSpeed;
    public float rotationSpeed;
    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Enemy");
        if (target == null)
        {

            target = GameObject.FindGameObjectWithTag("Boss");

        }

        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("FakeMissileTarget");
        }

    }

    // Update is called once per frame
    void Update()
    {
        findEnemy();

        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
        Vector3 vectorToTarget = target.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;

        if (angle < 90 && angle >= 80)
        {
            rotationSpeed = 10;
        }
        else if (angle < 80 && angle >= 70)
        {
            rotationSpeed = 20;
        }
        else if (angle < 70 && angle >= 60)
        {
            rotationSpeed = 30;
        }
        else if (angle < 60 && angle >= 50)
        {
            rotationSpeed = 40;
        }
        else if (angle < 50 && angle >= 40)
        {
            rotationSpeed = 50;
        }
        else if (angle < 40 && angle >= 30)
        {
            rotationSpeed = 60;
        }
        else if (angle < 30 && angle >= 20)
        {
            rotationSpeed = 70;
        }
        else if (angle < 20 && angle >= 10)
        {
            rotationSpeed = 75;
        }
        else if (angle < 10 && angle >= 0)
        {
            rotationSpeed = 80;
        }

        if (angle < 90 && angle > -90)
        {
            angle = angle - 90;
        }
        else if (angle == 90)
        {
            angle = 0;
        }

        Quaternion qt = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, qt, Time.deltaTime * rotationSpeed);

    }

    void findEnemy()
    {

        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Enemy");
        }

        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Boss");
        }

        if (target == null)
        {

            target = GameObject.FindGameObjectWithTag("FakeMissileTarget");

        }

        if (target.transform.position.y < gameObject.transform.position.y)
        {
            findEnemy();
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "FakeMissileTarget")
        {
            Destroy(gameObject);
        }
    }

}