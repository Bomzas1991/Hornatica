using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent < Rigidbody2D >();
    }

    void Update()
    {
        rb.velocity = transform.forward * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy(gameObject);

        if (collision.gameObject.tag == "Enemy")
        {
            return;
        }
    }
}
