using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonLock : MonoBehaviour
{
    public int requiredLevel;

    public GameObject lockOverlay;
    public Button button;

    void Start()
    {
        int unlockedLevel =
            PlayerPrefs.GetInt("UnlockedLevel", 1);

        bool unlocked =
            unlockedLevel >= requiredLevel;

        button.interactable = unlocked;

        lockOverlay.SetActive(!unlocked);
    }
}