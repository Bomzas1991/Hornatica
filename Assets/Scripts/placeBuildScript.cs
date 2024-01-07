using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placeBuildScript : MonoBehaviour
{
    public int value;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Vector3 newRotation = new Vector3(0, 0, transform.eulerAngles.z + 90);
            transform.eulerAngles = newRotation;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Building")
        {
            Destroy(gameObject);
        }
    }

}
