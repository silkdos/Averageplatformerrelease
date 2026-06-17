using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelProgress
{
    public static void UnlockNextLevel(int currentLevel)
    {
        int unlocked =
            PlayerPrefs.GetInt("UnlockedLevel", 1);

        int nextLevel = currentLevel + 1;

        if (nextLevel > unlocked)
        {
            PlayerPrefs.SetInt(
                "UnlockedLevel",
                nextLevel
            );

            PlayerPrefs.Save();
        }
    }
}