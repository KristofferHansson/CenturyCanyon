using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
   public void NewGame()
    {
        SceneManager.LoadScene("L01_VerticalSlice");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayLevel1()
    {
        SceneManager.LoadScene("L01_VerticalSlice");
    }

    public void PlayLevel2()
    {
        SceneManager.LoadScene("L02_Level_two");
    }

    public void PlayLevel3()
    {
        SceneManager.LoadScene("L03_Level3");
    }
}
