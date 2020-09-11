using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMissileScript : GameBase
{
    public float fireRate;

    public GameObject leftGun;
    public GameObject rightGun;

    Boolean firing = true;
    int count;

    public GameObject missile;
    // Start is called before the first frame update
    void Start()
    {
        base.init();

        count = 0;
    }

    private void Update()
    {
        if (manager.numOfBosses > 2 && count < 1)
        {
            StartCoroutine(fireMissile());
            count++;
        }

        if (fireRate > 5)
        {
            fireRate = 10 - manager.numOfBosses;
        }

    }

    IEnumerator fireMissile()
    {
        while (firing)
        {
            yield return new WaitForSeconds(1f);

            Instantiate(missile, leftGun.transform.position, Quaternion.identity);
            Instantiate(missile, rightGun.transform.position, Quaternion.identity);

            yield return new WaitForSeconds(fireRate-1f);
        }
    }
}
