using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        nextAttackTime = Time.time + attackDelay;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = new Vector3(mousePos.x, mousePos.y, 0);

        if (nextAttackTime < Time.time)
        {
            nextAttackTime = Time.time + attackDelay;
            Attack();
        }

    }

    private Camera camera;
    float nextAttackTime;
    public float attackDelay = 0.1f;
    public GameManager manager;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform shotPos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "UFO")
            manager.GameOver();
    }

    void Attack()
    {
        GameObject middleBullet = Instantiate(bulletPrefab, shotPos.position, shotPos.rotation);
        GameObject leftBullet = Instantiate(bulletPrefab, shotPos.position, shotPos.rotation);
        leftBullet.transform.Rotate(0, 0, 30);
        GameObject rightBullet = Instantiate(bulletPrefab, shotPos.position, shotPos.rotation);
        rightBullet.transform.Rotate(0, 0, -30);
    }
}
