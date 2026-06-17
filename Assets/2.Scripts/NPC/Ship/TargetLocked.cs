using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetLockUI : MonoBehaviour
{
    public PlayerFlightControl player;

    public RectTransform indicator;

    public Camera mainCamera;
    public Image targetImage;


    void Update()
    {
        Transform target = player.candidateTarget;

        if (target == null)
        {
            indicator.gameObject.SetActive(false);
            return;
        }

        indicator.gameObject.SetActive(true);

        Vector3 screenPos =
            mainCamera.WorldToScreenPoint(
                target.position
            );


        indicator.position = screenPos;

        if (screenPos.z < 0)
        {
            indicator.gameObject.SetActive(false);
            return;
        }

        if (player.lockedTarget == target)
        {
            targetImage.color = Color.red;

            indicator.rotation =
                Quaternion.Euler(0, 0, 0);
        }
        else
        {
            targetImage.color = Color.green;

            indicator.rotation =
                Quaternion.Euler(0, 0, 45);
        }
    }
}