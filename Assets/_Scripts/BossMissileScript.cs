using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMissileScript : GameBase
{
    public float fireRate;
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
    }

    IEnumerator fireMissile()
    {
        while (firing)
        {
            Instantiate(missile, gameObject.transform.position, Quaternion.identity);

            yield return new WaitForSeconds(fireRate);
        }
    }
}
