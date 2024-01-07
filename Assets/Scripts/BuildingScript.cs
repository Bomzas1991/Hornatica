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
    public GameObject[] prefabSilhoutte;
    public int prefabInt = 0;
    public int prefabSilhoutteInt = 0;

    public bool able;
    public TextMeshProUGUI budget;
    int leftToPlace = 1;

    public int[] value;
    public int valueInt;

    Vector3 worldPosition;
    Vector3 mousePos;

    private void Start()
    {
        //var MaXValue = Mathf.Max(prefab.Sort());
    }

    private void Update()
    {       
        var val = GetComponent<placeBuildScript>();

        if (Input.GetMouseButtonDown(0))
        {
            if (able)
            {
                mousePos = Input.mousePosition;
                mousePos.z = Camera.main.nearClipPlane;
                worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
                Instantiate(prefab[prefabInt], worldPosition, Quaternion.identity);

                int budgetInt = int.Parse(budget.text);
                budgetInt -= value[valueInt];
                budget.text = budgetInt.ToString();

            }
        }

        if (int.Parse(budget.text) <= 0)
        {
            able = false;
        }

        //Ray ray = Camera.main.ScreenPointToRay(mousePos);
        //RaycastHit hit;

        //if (Physics.Raycast(ray, out hit))
        //{

        //    if (hit.transform.tag == "Building")
        //    {
        //        return;
        //    }
        //    else
        //    {
        //        return;
        //    }
        //}

        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    Vector3 newRotation = new Vector3(0, 0, transform.eulerAngles.z + 90);
        //    transform.eulerAngles = newRotation;
        //}
    }

    public void Cube()
    {       
        prefabInt = 0;
        prefabSilhoutteInt = 0;
        //Instantiate(prefabSilhoutte[prefabSilhoutteInt], worldPosition, Quaternion.identity);

        valueInt = 1;
    }

    public void Rectangle()
    {        
        prefabInt = 1;
        prefabSilhoutteInt = 1;
        //Instantiate(prefabSilhoutte[prefabSilhoutteInt], worldPosition, Quaternion.identity);
        valueInt = 1;
    }

    public void Triangle()
    {       
        prefabInt = 2;
        prefabSilhoutteInt = 2;
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
