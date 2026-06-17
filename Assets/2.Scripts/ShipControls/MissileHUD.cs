using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissileHUD : MonoBehaviour
{
    public PlayerFlightControl player;

    public Image cooldownFill;

    void Update()
    {
        float remaining =
            Mathf.Max(
                0,
                player.nextMissileTime - Time.time
            );

        float progress =
            player.MissileCooldownRemaining /
            player.missileCooldown;

        cooldownFill.fillAmount = progress;
    }
}
