using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    private bool isPaused = false;

    public ThirdPersonController playerController;

    void Update()
    {
        if (GameOverMenu.instance != null &&
            GameOverMenu.instance.gameOverUI.activeSelf)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);

        Time.timeScale = 1f;

        playerController.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        isPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);

        Time.timeScale = 0f;

        playerController.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        isPaused = true;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;

        PlayerPrefs.SetString("SceneToLoad", "Main Menu");
        SceneManager.LoadScene("LoadingScene");
    }
}