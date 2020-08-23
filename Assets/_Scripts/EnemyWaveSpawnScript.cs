using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSpawnScript : GameBase
{
    public GameObject enemyWave1;
    public GameObject enemyWave2;
    public GameObject enemyWave3;
    public GameObject enemyWave4;
    public GameObject enemyWave5;
    public GameObject enemyWave6;

    public float waveWaitTime = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        base.init();
        StartCoroutine(enemyWaveSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator enemyWaveSpawn()
    {
        while (manager.running)
        {
            GameObject wave;
            int rand = Random.Range(1, 6);
            switch (rand)
            {
                case 1:
                    wave = enemyWave1;
                    break;
                case 2:
                    wave = enemyWave2;
                    break;
                case 3:
                    wave = enemyWave3;
                    break;
                case 4:
                    wave = enemyWave4;
                    break;
                case 5:
                    wave = enemyWave5;
                    break;
                default:
                    wave = enemyWave6;
                    break;
            }

            Instantiate(wave, new Vector3(0, 0, 0), Quaternion.identity);
            yield return new WaitForSeconds(waveWaitTime);


        }
    }

}
