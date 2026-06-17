using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHealth : MonoBehaviour
{
    public int maxHealth = 20;
    public int currentHealth;

    public GameObject explosionPrefab;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
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

        Instantiate(
            explosionPrefab,
            transform.position,
            Quaternion.identity
        );

        Destroy(gameObject);
    }
}
