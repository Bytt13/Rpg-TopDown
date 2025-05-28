using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{

    public GameObject gameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void GiveUp()
    {
        Application.Quit();
    }

    public void TryAgain()
    {
        Time.timeScale = 1f;
        gameOverPanel.SetActive(false);
        // Reload the current scene or reset the game state
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
