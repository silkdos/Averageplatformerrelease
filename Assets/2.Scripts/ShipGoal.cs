using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipGoal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ShipHealth health =
            other.GetComponentInParent<ShipHealth>();

        if (health != null)
        {
            PlayerFlightControl controller =
                other.GetComponent<PlayerFlightControl>();

            if (controller != null)
            {
                controller.enabled = false;
            }

            WinMenu.instance.ShowWinScreen();
        }
    }
}