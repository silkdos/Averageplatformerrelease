using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public int enemiesRequired = 4;

    private int enemiesKilled = 0;
    private bool goalUnlocked = false;

    [Header("Goal")]
    public GameObject goalPortal;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (goalPortal != null)
        {
            goalPortal.SetActive(false);
        }

        HUDManager.instance.UpdateObjective(
            enemiesKilled,
            enemiesRequired
        );

        HUDManager.instance.ShowNotification(
            "Eliminate " +
            enemiesRequired +
            " enemies to open the portal"
        );
    }

    public void EnemyKilled()
    {
        enemiesKilled++;

        HUDManager.instance.UpdateObjective(
            enemiesKilled,
            enemiesRequired
        );

        HUDManager.instance.ShowNotification(
            "Enemy Eliminated"
        );

        if (!goalUnlocked &&
            enemiesKilled >= enemiesRequired)
        {
            UnlockGoal();
        }
    }

    private void UnlockGoal()
    {
        goalUnlocked = true;

        if (goalPortal != null)
        {
            goalPortal.SetActive(true);
        }

        HUDManager.instance.ShowNotification(
            "Portal Unlocked! Let's get out of here!"
        );
    }

    public bool IsGoalUnlocked()
    {
        return goalUnlocked;
    }
}