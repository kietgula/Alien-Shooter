using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    void Start()
    {
        nextSpawnTime = Time.time + spawnDelay;
        crew = this.GetComponent<Crew>();

    }

    // Update is called once per frame
    void Update()
    {
        if (numOfUFO > 0 && nextSpawnTime<=Time.time)
        {
            SpawnUFO();
            numOfUFO--;
            nextSpawnTime = Time.time + spawnDelay;
        }
        
        else if (numOfUFO <= 0)
        {

        }
    }

    Crew crew;
    [SerializeField] GameObject UFO;
    public int numOfUFO = 12;
    [SerializeField] float spawnDelay = 1;
    private float nextSpawnTime;
    public void SpawnUFO()
    {
        GameObject ufo = Instantiate(UFO, this.transform.position, Quaternion.identity);
        crew.crews.Add(ufo);
        ufo.GetComponent<UFO>().Crew = crew;
        
    }
}
