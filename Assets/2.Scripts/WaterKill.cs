using UnityEngine;

public class KillWater : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth health = other.GetComponent<PlayerHealth>();

        if (health != null)
        {
            health.TakeDamage(9999);
        }
    }
}