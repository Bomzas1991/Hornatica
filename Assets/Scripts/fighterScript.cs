using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fighterScript : MonoBehaviour
{
    public Vector3 target;
    public GameObject bullet;

    private float time = 0.0f;
    public float bulletShoot = 2f;

    void Update()
    {
        FindClosestEnemy();

        transform.LookAt(target);

        time += Time.deltaTime;

        if (time >= bulletShoot)
        {
            time = 0.0f;

            Instantiate(bullet, transform.position, transform.rotation);
            // execute block of code here
        }
    }

    void FindClosestEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        EnemyScript closestEnemy = null;
        EnemyScript[] allEnemies = GameObject.FindObjectsOfType<EnemyScript>();

        foreach (EnemyScript currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;

                target = closestEnemy.transform.position;
            }
        }

        Debug.DrawLine(transform.position, closestEnemy.transform.position);
    }
}
