using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinMenu : MonoBehaviour
{
    public static WinMenu instance;

    public GameObject winMenuUI;

    public TMP_Text timeText;
    public TMP_Text coinsText;

    public AudioClip victorySound;

    private AudioSource audioSource;
    private AudioSource musicSource;

    private void Awake()
    {
        instance = this;

        audioSource = GetComponent<AudioSource>();

        GameObject musicManager = GameObject.Find("MusicManager");

        if (musicManager != null)
        {
            musicSource = musicManager.GetComponent<AudioSource>();
        }
    }

    public void ShowWinScreen()
    {
        winMenuUI.SetActive(true);

        // Bajar música del nivel
        if (musicSource != null)
        {
            musicSource.volume = 0.05f;
        }

        // Sonido de victoria
        if (victorySound != null)
        {
            audioSource.PlayOneShot(victorySound, 0.9f);
        }

        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Mostrar tiempo
        float time = HUDManager.instance.GetLevelTime();

        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        timeText.text = "Time: " +
            string.Format("{0:00}:{1:00}", minutes, seconds);

        // Mostrar monedas
        coinsText.text = "Tokens: " +
            CoinManager.instance.coins;
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;

        PlayerPrefs.SetString("SceneToLoad", "Main Menu");
        SceneManager.LoadScene("LoadingScene");
    }
}