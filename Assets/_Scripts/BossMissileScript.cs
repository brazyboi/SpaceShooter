using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMissileScript : GameBase
{
    public float fireRate;
    Boolean firing = true;

    public GameObject missile;
    // Start is called before the first frame update
    void Start()
    {
        base.init();
        StartCoroutine(fireMissile());
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
