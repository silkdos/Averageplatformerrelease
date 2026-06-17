using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public static HUDManager instance;

    public TMP_Text coinsText;
    public TMP_Text healthText;
    public TMP_Text timerText;
    public Slider healthSlider;
    public TMP_Text objectiveText;
    public TMP_Text notificationText;
    private float levelTimer;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        levelTimer += Time.deltaTime;

        int minutes = Mathf.FloorToInt(levelTimer / 60);
        int seconds = Mathf.FloorToInt(levelTimer % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void UpdateCoins(int coins)
    {
        coinsText.text = "Tokens: " + coins;
    }

    public void UpdateHealth(int currentHealth, int maxHealth)
    {
        int displayedHealth = Mathf.Max(currentHealth, 0);

        healthSlider.maxValue = maxHealth;
        healthSlider.value = displayedHealth;

        healthText.text = displayedHealth + " / " + maxHealth;
    }

    public float GetLevelTime()
    {
        return levelTimer;
    }

    public void UpdateObjective(int current, int required)
    {
        objectiveText.text =
            "Enemies Required " +
            current +
            "/" +
            required;
    }

    public void ShowNotification(string message)
    {
        StopAllCoroutines();
        StartCoroutine(NotificationRoutine(message));
    }

    IEnumerator NotificationRoutine(string message)
    {
        notificationText.text = message;

        yield return new WaitForSeconds(3f);

        notificationText.text = "";
    }
}