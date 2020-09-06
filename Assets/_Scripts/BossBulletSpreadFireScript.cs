using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletSpreadFireScript : GameBase
{
    public GameObject bulletBoss;

    Boolean firing = true;
    public float spreadFireRate = 2.0f;
    int count = 0;

    public GameObject LeftGun1;
    public GameObject LeftGun2;
    public GameObject RightGun1;
    public GameObject RightGun2;

    // Start is called before the first frame update
    void Start()
    {
        base.init();
        StartCoroutine(spreadFire());
    }

    // Update is called once per frame
    void Update()
    {
        if (spreadFireRate > 5.0f && count < manager.numOfBosses)
        {
            spreadFireRate -= manager.numOfBosses * 1.0f;
            if (count < 4)
            {
                count++;
            }

        }

    }

    IEnumerator spreadFire()
    {
        while (firing)
        {
            Instantiate(bulletBoss, LeftGun1.transform.position, Quaternion.identity);
            Instantiate(bulletBoss, LeftGun2.transform.position, Quaternion.identity);
            Instantiate(bulletBoss, RightGun1.transform.position, Quaternion.identity);
            Instantiate(bulletBoss, RightGun2.transform.position, Quaternion.identity);

            yield return new WaitForSeconds(spreadFireRate);
        }
    }

}
