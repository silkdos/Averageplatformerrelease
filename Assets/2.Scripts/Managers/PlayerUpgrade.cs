using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class PlayerUpgrades : MonoBehaviour
{
    private ThirdPersonController controller;
    private PlayerCombat combat;
    private PlayerHealth health;

    void Start()
    {
        controller = GetComponent<ThirdPersonController>();
        combat = GetComponent<PlayerCombat>();
        health = GetComponent<PlayerHealth>();

        ApplyUpgrades();
    }

    void ApplyUpgrades()
    {
        int speedLevel =
            PlayerPrefs.GetInt("SpeedUpgradeLevel", 0);

        int jumpLevel =
            PlayerPrefs.GetInt("JumpUpgradeLevel", 0);

        int damageLevel =
            PlayerPrefs.GetInt("DamageUpgradeLevel", 1);

        int hpLevel =
            PlayerPrefs.GetInt("HPUpgradeLevel", 1);

        float speedMultiplier =
            1f + (speedLevel * 0.15f);

        float jumpMultiplier =
            1f + (jumpLevel * 0.15f);

        int damageMultiplier =
            10 * damageLevel;

        int hpMultiplier =
            25 * hpLevel;

        controller.MoveSpeed *= speedMultiplier;
        controller.SprintSpeed *= speedMultiplier;

        controller.JumpHeight *= jumpMultiplier;

        combat.ApplyDamageUpgrade(damageMultiplier);

        health.ApplyHealthUpgrade(hpMultiplier);

        Debug.Log("Velocidad x" + speedMultiplier);
        Debug.Log("Salto x" + jumpMultiplier);

    }
}