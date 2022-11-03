using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crew : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        crews = new List<GameObject>();
        spawner = this.GetComponent<Spawner>();
        crewSize = spawner.numOfUFO; //at Start, num of UFO is how many UFO will be spawned

    }

    // Update is called once per frame


    void Update()
    {
        if (crews.Count == crewSize && isLineUp())
        {
            startRandomMoving();
        }

        if (crewSize <= 0)
            manager.GameWin();

    }

    public GameManager manager;
    public List<GameObject> crews;
    Spawner spawner;
    public int crewSize;
    int maxCrewWide = 4;
    int maxCrewHigh = 5;

    public float crewDistance = 0;
    private const int maximunDestination = 100;

    void startRandomMoving()
    {
        float nextPosX = Random.Range(-7f, 3f);
        float nextPosY = Random.Range(1f, 3f);
        for (int u = 0; u<crews.Count;u++)
        {
            int posX = u % maxCrewWide;
            int posY = u / maxCrewWide;
            crews[u].GetComponent<UFO>().destinations.Add(new Vector3(nextPosX+posX*crewDistance, nextPosY + posY*crewDistance,0));
        }
    }

    bool isLineUp()
    {
        foreach (GameObject ufo in crews)
        {
            if (ufo.GetComponent<UFO>().destinations.Count > 0)
                return false;
        }
        return true;
    }

    public void RemoveUFO(GameObject ufo)
    {
        int index = crews.IndexOf(ufo);
        crews.RemoveAt(index);
    }
}
