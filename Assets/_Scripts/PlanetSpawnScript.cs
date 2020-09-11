using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawnScript : MonoBehaviour
{

    public GameObject planet1;
    public GameObject planet2;
    public GameObject planet3;

    // Start is called before the first frame update
    void Start()
    {
       // StartCoroutine(spawnPlanet());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnPlanet()
    {
        while (true)
        {
            GameObject targetPlanet;
            yield return new WaitForSeconds(30.0f);

            int random = Random.Range(0, 3);

            if (random == 0)
            {
                targetPlanet = planet1;
            } else if (random == 1)
            {
                targetPlanet = planet2;
            } else
            {
                targetPlanet = planet3;
            }

            int xPos = Random.Range(-Screen.width + 150, Screen.width - 150) / 100;

            Instantiate(targetPlanet, new Vector3(xPos, 7, -5), Quaternion.identity);

        }
    }

}
