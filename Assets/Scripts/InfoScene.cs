using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfoScene : MonoBehaviour
{
    public GameObject[] displayInfo;
    int info = 0;

    public void switchSceneRight()
    {
        info++;

        if (info > 2)
        {
            info = 0;
            displayInfo[1].SetActive(false);
            displayInfo[2].SetActive(false);
        }

        displayInfo[info].SetActive(true);
    }

    public void back()
    {
        SceneManager.LoadScene("Main menu");
    }
}
