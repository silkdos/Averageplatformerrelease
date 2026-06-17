using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateManager : MonoBehaviour
{
    void Awake()
    {
        QualitySettings.vSyncCount = 0; // Desactiva VSync
        Application.targetFrameRate = 60;
    }
}