﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpParticleSystemScript : MonoBehaviour
{
    ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();

    }
    // Update is called once per frame
    void Update()
    {
        var main = ps.main;
        if (gameObject.tag == "BulletHitEffect")
        {
            main.simulationSpeed = 10;
        } 
        if (gameObject.tag == "MissileHitEffect")
        {
            main.simulationSpeed = 10;
        }
        
    }
}