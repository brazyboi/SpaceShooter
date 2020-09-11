using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletSpreadFireScript : GameBase
{
    public GameObject bulletBoss;
    public GameObject bulletBossSpread;

    Boolean firing = true;
    public float spreadFireRate = 2.0f;
    int count = 0;
    int firstTime;

    public GameObject LeftGun1;
    public GameObject LeftGun2;
    public GameObject RightGun1;
    public GameObject RightGun2;
    public GameObject centerGun;

    // Start is called before the first frame update
    void Start()
    {
        base.init();
        StartCoroutine(spreadFire1());
        StartCoroutine(spreadFire2());
        firstTime = 0;
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

    IEnumerator spreadFire1()
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

    IEnumerator spreadFire2()
    {
        while (firing)
        {
            if (firstTime == 0)
            {
                firstTime++;
                yield return new WaitForSeconds(spreadFireRate / 2);
            }

            for (int i = 0; i < 10; i++) {
                Instantiate(bulletBossSpread, centerGun.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
            }

            yield return new WaitForSeconds(spreadFireRate);
        }
    }

}
