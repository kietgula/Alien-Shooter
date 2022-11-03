using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float bulletSpeed;

    void Start()
    {
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * bulletSpeed;
    }
}
