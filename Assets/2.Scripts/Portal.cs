using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour
{
    public Portal destinationPortal;

    private bool canTeleport = true;

    private void OnTriggerEnter(Collider other)
    {
        if (!canTeleport)
            return;

        PlayerHealth player = other.GetComponent<PlayerHealth>();

        if (player != null)
        {
            StartCoroutine(TeleportPlayer(other.transform));
        }
    }

    IEnumerator TeleportPlayer(Transform player)
    {
        canTeleport = false;
        destinationPortal.canTeleport = false;

        CharacterController controller =
            player.GetComponent<CharacterController>();

        if (controller != null)
        {
            controller.enabled = false;
        }
       
        player.position = destinationPortal.transform.position;
     
        if (controller != null)
        {
            controller.enabled = true;
        }

        yield return new WaitForSeconds(0.5f);

        canTeleport = true;
        destinationPortal.canTeleport = true;
    }
}
