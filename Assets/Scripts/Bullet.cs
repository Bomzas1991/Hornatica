using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = transform.right * speed;

        if (transform.position.x > 10 || transform.position.x < -10 || transform.position.y < -6 || transform.position.y > 6)
        {
            Destroy(gameObject);
        }
    }
}
