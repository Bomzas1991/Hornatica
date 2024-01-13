using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile : MonoBehaviour
{
    public bool Occupied;

    public Color green;
    public Color red;

    private SpriteRenderer rend;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Occupied)
        {
            rend.color = red;
        }
        else
        {
            rend.color = green;
        }
    }
}
