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
    [SerializeField] private Text treeCountText;
    [SerializeField] private Text bushCountText;
    [SerializeField] private Text energyCountText;

    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
        levelCompletePanel.SetActive(false);
    }

    // Display PP resource amounts
    public void SetVineCount(int num)
    {
        if (vineCountText != null)
            vineCountText.text = num.ToString();
    }
    public void SetTreeCount(int num)
    {
        if (treeCountText != null)
            treeCountText.text = num.ToString();
    }
    public void SetBushCount(int num)
    {
        if (bushCountText != null)
            bushCountText.text = num.ToString();
    }

    // Display PF resource amount
    public void SetEnergyCount(int num)
    {
        if (energyCountText != null)
            energyCountText.text = num.ToString();
    }

    public void ShowEndGamePanel()
    {
        gameOverPanel.SetActive(true);
    }

    public void ShowLevelCompletePanel()
    {
        levelCompletePanel.SetActive(true);
    }

    public void EHNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
