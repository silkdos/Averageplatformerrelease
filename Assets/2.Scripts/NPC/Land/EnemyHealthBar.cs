using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public TMP_Text healthText;

    public void UpdateHealth(int currentHealth, int maxHealth)
    {
        int displayedHealth = Mathf.Max(currentHealth, 0);

        healthSlider.maxValue = maxHealth;
        healthSlider.value = displayedHealth;

        healthText.text = displayedHealth + " / " + maxHealth;
    }
}
