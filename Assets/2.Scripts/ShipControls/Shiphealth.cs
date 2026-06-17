using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ShipHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public GameObject explosionPrefab;

    public GameObject shipModel;

    private bool isDead = false;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (isDead)
            return;

        currentHealth -= damage;
        Debug.Log(
            gameObject.name +
            " HP: " +
            currentHealth +
            "/" +
            maxHealth
        );

        HUDManager.instance.UpdateHealth(
            currentHealth,
            maxHealth
        );

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead)
            return;

        isDead = true;

        if (shipModel != null)
        {
            shipModel.SetActive(false);
        }

        Debug.Log("SHIP DESTROYED");

        // Desactivar controles
        PlayerFlightControl flight =
            GetComponent<PlayerFlightControl>();

        if (flight != null)
        {
            flight.enabled = false;
        }

        // Detener física
        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;
        }

        // Ocultar modelo
        if (explosionPrefab != null)
        {
            Instantiate(
                explosionPrefab,
                transform.position,
                Quaternion.identity
            );
        }

        StartCoroutine(DeathRoutine());
    }

    private IEnumerator DeathRoutine()
    {
        yield return new WaitForSeconds(2f);

        GameOverMenu.instance.ShowGameOver();

        Destroy(gameObject);
    }
}
