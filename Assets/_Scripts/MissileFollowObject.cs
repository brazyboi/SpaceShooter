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
        target = GameObject.FindGameObjectWithTag("FakeMissileTarget");

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
        Vector3 vectorToTarget = target.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        print(angle);
        Quaternion qt = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, qt, Time.deltaTime * rotationSpeed);
        
    }
}