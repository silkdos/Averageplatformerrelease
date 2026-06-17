using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;

    // Monedas del nivel actual
    public int coins = 0;

    // Banco global
    public int totalCoins = 0;

    private void Awake()
    {
        instance = this;

        // Cargar banco guardado
        totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
    }

    public void AddCoin(int amount)
    {
        coins += amount;

        Debug.Log("Tokens: " + coins);

        HUDManager.instance.UpdateCoins(coins);
    }

    public void SaveCoinsToBank()
    {
        totalCoins += coins;

        PlayerPrefs.SetInt("TotalCoins", totalCoins);

        PlayerPrefs.Save();

        Debug.Log("Total Tokens: " + totalCoins);
    }
}