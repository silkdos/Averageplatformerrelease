using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject levelSelectPanel;

    public GameObject UpgradePanel;

    public TMP_Text bankText;

    public Button level1Button;
    public Button level2Button;
    public Button level3Button;
    public Button level4Button;
    public Button level5Button;
    public Button level6Button;



    void Start()
    {
        int totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);

        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        bankText.text = "Bank: " + totalCoins;
    }

    public void PlayGame()
    {
        levelSelectPanel.SetActive(true);
    }

    public void CloseLevelSelect()
    {
        levelSelectPanel.SetActive(false);
    }

    public void Upgrades()
    {
        UpgradePanel.SetActive(true);
    }

    public void CloseUpgrades()
    {
        UpgradePanel.SetActive(false);
    }

    public void LoadLevel1()
    {
        PlayerPrefs.SetString("SceneToLoad", "Level 1");
        SceneManager.LoadScene("LoadingScene");
    }

    public void LoadLevel2()
    {
        PlayerPrefs.SetString("SceneToLoad", "Level 2");
        SceneManager.LoadScene("LoadingScene");
    }

    public void LoadLevel3()
    {
        PlayerPrefs.SetString("SceneToLoad", "Level 3");
        SceneManager.LoadScene("LoadingScene");
    }

    public void LoadLevel4()
    {
        PlayerPrefs.SetString("SceneToLoad", "Level 4");
        SceneManager.LoadScene("LoadingScene");
    }

    public void LoadLevel5()
    {
        PlayerPrefs.SetString("SceneToLoad", "Level 5");
        SceneManager.LoadScene("LoadingScene");
    }

    public void LoadLevel6()
    {
        PlayerPrefs.SetString("SceneToLoad", "Level 6");
        SceneManager.LoadScene("LoadingScene");
    }

    public void QuitGame()
    {
        Debug.Log("Salir del juego");

        Application.Quit();
    }
}
