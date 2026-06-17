using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [Header("Loot")]
    public GameObject coinPrefab;
    public int coinsToDrop = 1;


    public int maxHealth = 100;
    public int currentHealth;

    [Header("Muerte")]
    public float destroyAfterSeconds = 5f;

    private bool isDead = false;

    private Animator animator;
    private Collider enemyCollider;
    private EnemyController enemyController;
    private EnemyHealthBar healthBar;

    Rigidbody rb;

    void Start()
    {
        currentHealth = maxHealth;

        animator = GetComponent<Animator>();
        enemyCollider = GetComponent<Collider>();
        enemyController = GetComponent<EnemyController>();

        rb = GetComponent<Rigidbody>();
        healthBar = GetComponentInChildren<EnemyHealthBar>();

        if (healthBar != null)
        {
            healthBar.UpdateHealth(currentHealth, maxHealth);
        }
    }

    public void TakeDamage(int damage)
    {
        if (isDead)
            return;

        currentHealth -= damage;

        if (healthBar != null)
        {
            healthBar.UpdateHealth(currentHealth, maxHealth);
        }


        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;

        // Parar IA
        if (enemyController != null)
            enemyController.enabled = false;

        // Evitar más colisiones
        if (enemyCollider != null)
            enemyCollider.enabled = false;

        // Animación de muerte
        if (animator != null)
            animator.SetTrigger("Die");

        if (rb != null)
        {
            rb.isKinematic = true;
            rb.useGravity = false;
        }

        StartCoroutine(DestroyAfterDelay());
    }

    private void DropCoins()
    {
        for (int i = 0; i < coinsToDrop; i++)
        {
            Vector3 spawnPosition =
                transform.position +
                new Vector3(
                    Random.Range(-0.5f, 0.5f),
                    0.5f,
                    Random.Range(-0.5f, 0.5f)
                );

            Instantiate(
                coinPrefab,
                spawnPosition,
                Quaternion.identity
            );
        }
    }
    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(2f);

        DropCoins();

        yield return new WaitForSeconds(3f);

        Destroy(gameObject);
    }
}