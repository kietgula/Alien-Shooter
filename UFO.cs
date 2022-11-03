using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {

        if (destinations.Count <= 0)
        {
            Debug.Log(this.gameObject.name.ToString() + "dont have destination");
        }
        else if (Vector3.Distance(this.transform.position,destinations[0]) > distanceOffset)
        {
            move_to(destinations[0]);
        }
        else if (Vector3.Distance(this.transform.position,destinations[0]) <= distanceOffset)
        {
            destinations.RemoveAt(0); 
        }
    }

    [SerializeField] float moveSpeed = 1;
    [SerializeField] public List<Vector3> destinations;
    public Crew Crew;
    private float distanceOffset = 0.1f; //allow the UFO near by destination

    private void move_to(Vector3 newPos)
    {
        Vector3 direction = newPos - this.transform.position;
        direction.Normalize();
        this.transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Crew.RemoveUFO(this.gameObject);
            Crew.crewSize--;
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            
        }
    }


}
