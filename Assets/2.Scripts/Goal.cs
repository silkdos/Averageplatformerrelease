using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Goal : MonoBehaviour
{

    public int currentLevel = 1;

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth health = other.GetComponent<PlayerHealth>();

        if (health != null)
        {
            ThirdPersonController controller =
                other.GetComponent<ThirdPersonController>();

            if (controller != null)
            {
                controller.enabled = false;
            }

            CoinManager.instance.SaveCoinsToBank();

            WinMenu.instance.ShowWinScreen();

            LevelProgress.UnlockNextLevel(currentLevel);
        }
    }
}