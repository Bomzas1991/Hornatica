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

    public TextMeshProUGUI Day; 
    public TextMeshProUGUI currentTime;

    public int[] value;
    public int valueInt;

    public tile[] tiles;
    public GameObject enemy;

    public int moneyPerSecond;
    public int dayLength = 10;
    float timer = 0;
    float spawnTimer = 0;
    float dayTimer = 0;
    bool kingOn = false;
    bool night = false;
    int currentDayCount = 0;

    private void Update()
    {
        timer += Time.deltaTime;
        spawnTimer += Time.deltaTime;
        dayTimer += Time.deltaTime;

        if (dayTimer > dayLength)
        {
            night = !night;

            if (night == false)
            {
                currentTime.text = "Current Time: Day";
                int day = int.Parse(Day.text);
                day += 1;
                Day.text = day.ToString();
            }
            else
            {
                currentTime.text = "Current Time: Night";
            }

            dayTimer = 0;
        }

        if (spawnTimer > 3 && kingOn == true && night == true)
        {
            Spawn();
            spawnTimer = 0;
        }

        if (timer > 1)
        {
            int moneyD = int.Parse(budget.text);
            moneyD += moneyPerSecond;
            budget.text = moneyD.ToString();

            timer = 0;
        }

        if (Input.mousePosition.x > 660 || Input.mousePosition.y < 140)
        {
            moneyLeft = false;
        }
        else moneyLeft = true;

        int moneyE = int.Parse(budget.text);

        if (moneyE <= 0)
        {
            moneyLeft = false;
        }

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

            if (nearestTile.Occupied == false && moneyLeft == true)
            {
                Instantiate(prefab[prefabInt], nearestTile.transform.position, Quaternion.identity);
                nearestTile.Occupied = true;
                int money = int.Parse(budget.text);
                money -= value[valueInt];
                budget.text = money.ToString();

                if (leftToPlace == 0)
                {
                    prefabInt = 0;
                    valueInt = 1;

                    leftToPlace += 2;
                    kingOn = true;
                }

                if (prefabInt == 1 && valueInt == 1)
                {
                    moneyPerSecond += 1;
                }
            }
        }
    }

    void Spawn()
    {
        Instantiate(enemy, new Vector3(Random.Range(-10f, 10), Random.Range(-6f, 6f), 0), Quaternion.identity);
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
        if (leftToPlace == 1)
        {
            leftToPlace--;
            prefabInt = 6;
            valueInt = 6;
        }
    }

}
