using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public GameObject explosionPrefab;
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

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (isDead)
            return;

        isDead = true;

        Collider col = GetComponent<Collider>();

        if (col != null)
        {
            col.enabled = false;
        }
        Instantiate(
            explosionPrefab,
            transform.position,
            Quaternion.identity
        );

        LevelManager.instance.EnemyKilled();

        Destroy(gameObject);
    }
}
