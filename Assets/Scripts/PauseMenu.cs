using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }

            else
            {
                Pause();
            }
        }
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        AudioListener.volume = 1;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        AudioListener.volume = 0;
    }

    public void ResumeGame()
    {
        Resume();
    }

    public void RestartLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        {
            SceneManager.LoadScene(currentLevel);
            Resume();
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Resume();
    }

    public void Exit()
    {
        Application.Quit();
    }
}