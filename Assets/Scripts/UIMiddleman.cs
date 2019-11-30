using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIMiddleman : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject levelCompletePanel;
    [SerializeField] private Text vineCountText;

    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
        levelCompletePanel.SetActive(false);
    }

    public void SetVineCount(int num)
    {
        if (vineCountText != null)
            vineCountText.text = num.ToString();
    }

    public void ShowEndGamePanel()
    {
        gameOverPanel.SetActive(true);
    }

    public void ShowLevelCompletePanel()
    {
        levelCompletePanel.SetActive(true);
    }

    public void EHRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void EHQuit()
    {
        Application.Quit();
    }
}
