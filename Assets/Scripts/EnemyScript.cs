using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyScript : MonoBehaviour
{
    GameObject king;
    GameObject Building;
    public float speed;

    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        king = GameObject.FindGameObjectWithTag("Player");
        Building = GameObject.FindGameObjectWithTag("Building");
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, king.transform.position, speed * Time.deltaTime);
        }
        else
        {
            return;
        }

        if (Vector3.Distance(transform.position, king.transform.position) < 0.001f)
        {
            Destroy(gameObject);
        }

        else if (Vector3.Distance(transform.position, Building.transform.position) < 0.001f)
        {
            canMove = false;
            print("touched");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision);
    }
}

