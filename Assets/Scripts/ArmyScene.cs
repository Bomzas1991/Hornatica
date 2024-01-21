using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ArmyScene : MonoBehaviour
{
    GameObject enemy;
    float time;
    public GameObject bullet;
    public Transform[] firePoints;
    public Transform firePoints1;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        //transform.LookAt(enemy.transform);

        if (time > 2)
        {
            Shoot();
            time = 0;
        }
    }

    void Shoot()
    {
        //foreach (var firePoint in firePoints)
        //{
        //    Instantiate(bullet, firePoint.position, firePoint.rotation);
        //}
        Instantiate(bullet, firePoints1.position, firePoints1.rotation);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision);
    }
}
