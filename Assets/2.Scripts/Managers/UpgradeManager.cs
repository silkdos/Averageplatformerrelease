using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager instance;

    public TMP_Text coinsText;

    public TMP_Text speedLevelText;
    public TMP_Text jumpLevelText;
    public TMP_Text damageLevelText;
    public TMP_Text hpLevelText;

    public TMP_Text speedButtonText;
    public TMP_Text jumpButtonText;
    public TMP_Text damageButtonText;
    public TMP_Text hpButtonText;

    private int totalCoins;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        LoadCoins();

        UpdateUI();
    }

    void LoadCoins()
    {
        totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
    }

    void UpdateUI()
    {
        int speedLevel =
            PlayerPrefs.GetInt("SpeedUpgradeLevel", 0);

        int jumpLevel =
            PlayerPrefs.GetInt("JumpUpgradeLevel", 0);

        int damageLevel =
            PlayerPrefs.GetInt("DamageUpgradeLevel", 1);

        int hpLevel =
            PlayerPrefs.GetInt("HPUpgradeLevel", 1);

        int speedCost = 25 + (speedLevel * 30);
        int jumpCost = 25 + (jumpLevel * 30);
        int damageCost = (damageLevel * 30);
        int hpCost = (hpLevel * 30);

        coinsText.text =
            "Bank: " + totalCoins;

        speedLevelText.text =
            "Speed Level " + speedLevel;

        jumpLevelText.text =
            "Jump Level " + jumpLevel;

        damageLevelText.text =
            "Damage Level " + damageLevel;

        hpLevelText.text =
            "Health Level " + hpLevel;

        speedButtonText.text =
            "(" + speedCost + ")";

        jumpButtonText.text =
            "(" + jumpCost + ")";

        damageButtonText.text =
            "(" + damageCost + ")";

        hpButtonText.text =
            "(" + hpCost + ")";
    }

    public void UpgradeSpeed()
    {
        int currentLevel =
            PlayerPrefs.GetInt("SpeedUpgradeLevel", 0);

        int cost = 25 + (currentLevel * 30);

        if (totalCoins >= cost)
        {
            totalCoins -= cost;

            currentLevel++;

            PlayerPrefs.SetInt(
                "SpeedUpgradeLevel",
                currentLevel
            );

            SaveAll();
        }
    }

    public void UpgradeJump()
    {
        int currentLevel =
            PlayerPrefs.GetInt("JumpUpgradeLevel", 0);

        int cost = 25 + (currentLevel * 30);

        if (totalCoins >= cost)
        {
            totalCoins -= cost;

            currentLevel++;

            PlayerPrefs.SetInt(
                "JumpUpgradeLevel",
                currentLevel
            );

            SaveAll();
        }
    }

    public void UpgradeDamage()
    {
        int currentLevel =
            PlayerPrefs.GetInt("DamageUpgradeLevel", 0);

        int cost = 25 + (currentLevel * 30);

        if (totalCoins >= cost)
        {
            totalCoins -= cost;

            currentLevel++;

            PlayerPrefs.SetInt(
                "DamageUpgradeLevel",
                currentLevel
            );

            SaveAll();
        }
    }

    public void UpgradeHP()
    {
        int currentLevel =
            PlayerPrefs.GetInt("HPUpgradeLevel", 0);

        int cost = 25 + (currentLevel * 30);

        if (totalCoins >= cost)
        {
            totalCoins -= cost;

            currentLevel++;

            PlayerPrefs.SetInt(
                "HPUpgradeLevel",
                currentLevel
            );

            SaveAll();
        }
    }

    

    public void ResetUpgrades()
    {
        PlayerPrefs.SetInt("SpeedUpgradeLevel", 0);
        PlayerPrefs.SetInt("JumpUpgradeLevel", 0);
        PlayerPrefs.SetInt("DamageUpgradeLevel", 1);
        PlayerPrefs.SetInt("HPUpgradeLevel", 1);

        SaveAll();

        Debug.Log("Mejoras reseteadas");
    }

    public void ResetBank()
    {
        totalCoins = 0;

        SaveAll();

        Debug.Log("Banco reseteado");
    }

    void SaveAll()
    {
        PlayerPrefs.SetInt("TotalCoins", totalCoins);

        PlayerPrefs.Save();

        UpdateUI();
    }
}