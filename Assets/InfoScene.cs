using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfoScene : MonoBehaviour
{
    public GameObject[] displayInfo;

    public void switchSceneRight()
    {
        int info = 1;
        info++;

        displayInfo[info].SetActive(true);

        if (info > 3)
        {
            info = 1;
        }
    }
    public void switchSceneLeft()
    {
        int info = 1;
        info--;

        displayInfo[info].SetActive(true);

        if (info < 1)
        {
            info = 3;
        }
    }

    public void back()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
