using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuScript : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Options()
    {
        SceneManager.LoadScene("OptionsScene");
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("Main menu");
    }

    public void infoScene()
    {
        SceneManager.LoadScene("InfoScene");
    }
}
