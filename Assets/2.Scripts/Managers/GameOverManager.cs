using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public static GameOverMenu instance;

    public GameObject gameOverUI;

    public AudioClip gameOver;

    private AudioSource audioSource;

    private AudioSource musicSource;

    private void Awake()
    {
        instance = this;

        audioSource = GetComponent<AudioSource>();

        musicSource = GameObject.Find("MusicManager")
        .GetComponent<AudioSource>();
    }

    public void ShowGameOver()
    {
        gameOverUI.SetActive(true);

        if (gameOver != null)
        {
            audioSource.PlayOneShot(gameOver, 0.9f);
        }
        if (musicSource != null)
        {
            musicSource.volume = 0.05f;
        }

        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}