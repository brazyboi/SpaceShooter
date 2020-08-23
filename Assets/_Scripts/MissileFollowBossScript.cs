using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileFollowBossScript : MonoBehaviour
{
    public GameObject target;
    public float moveSpeed;
    public float rotationSpeed;
    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        if (target == null)
        {

            target = GameObject.FindGameObjectWithTag("FakeMissileTarget");

        }

    }

    // Update is called once per frame
    void Update()
    {
        findPlayer();

        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
        Vector3 vectorToTarget = target.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;

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

    void findPlayer()
    {
        if (target == null)
        {

            target = GameObject.FindGameObjectWithTag("FakeMissileTarget");

        }
    }
}
