using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;


public class BuildingScript : MonoBehaviour
{
    public GameObject[] prefab;
    public int prefabInt = 0;

    public TextMeshProUGUI budget;
    bool moneyLeft = true;
    int leftToPlace = 1;

    public int[] value;
    public int valueInt;

    public tile[] tiles;

    private void Update()
    {       
        if (Input.GetMouseButtonDown(0) && moneyLeft == true)
        {
            tile nearestTile = null;
            float nearestDistance = float.MaxValue;
            foreach (tile tile in tiles)
            {
                float dist = Vector2.Distance(tile.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
                if (dist < nearestDistance)
                {
                    nearestDistance = dist;
                    nearestTile = tile;
                }
            }

            if (nearestTile.Occupied == false)
            {
                Instantiate(prefab[prefabInt], nearestTile.transform.position, Quaternion.identity);
                nearestTile.Occupied = true;
                int money = int.Parse(budget.text);
                money -= value[valueInt];
                budget.text = money.ToString();
            }
        }

        if (int.Parse(budget.text) <= 0)
        {
            moneyLeft = false;
        }
    }

    public void Cube()
    {       
        prefabInt = 0;
        //Instantiate(prefabSilhoutte[prefabSilhoutteInt], worldPosition, Quaternion.identity);

        valueInt = 1;
    }

    public void Rectangle()
    {        
        prefabInt = 1;
        //Instantiate(prefabSilhoutte[prefabSilhoutteInt], worldPosition, Quaternion.identity);
        valueInt = 1;
    }

    public void Triangle()
    {       
        prefabInt = 2;
        //Instantiate(prefabSilhoutte[prefabSilhoutteInt], worldPosition, Quaternion.identity);

        valueInt = 4;
    }


    public void Yellow()
    {
        prefabInt = 3;
        valueInt = 5;
    }

    public void Green()
    {
        prefabInt = 4;
        valueInt = 4;
    }

    public void Red()
    {
        prefabInt = 5;
        valueInt = 3;
    }

    public void king()
    {
        if (leftToPlace == 0)
        {
            prefabInt = 0;
            valueInt = 6;
        }
        else
        {
            prefabInt = 6;
            leftToPlace--;   
        }
    }

}
