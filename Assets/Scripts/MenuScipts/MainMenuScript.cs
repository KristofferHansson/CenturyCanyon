using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
   public void NewGame()
    {
        //SceneManager.LoadScene("L01_VerticalSlice");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayTutorial()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayLevel1()
    {
        SceneManager.LoadScene(2);
    }

    public void PlayLevel2()
    {
        SceneManager.LoadScene(3);
    }

    public void PlayLevel3()
    {
        SceneManager.LoadScene(4);
    }

    public void PlayLevel4()
    {
        SceneManager.LoadScene(5);
    }
}
