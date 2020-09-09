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
        } else if (angle < 80 && angle >= 70)
        {
            rotationSpeed = 20;
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
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "FakeMissileTarget")
        {
            Destroy(gameObject);
        }    
    }

}