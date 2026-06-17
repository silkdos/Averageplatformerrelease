using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Referencias")]
    private Transform player;
    private Animator animator;

    [Header("Movimiento")]
    public float moveSpeed = 2f;
    public float rotationSpeed = 5f;

    [Header("IA")]
    public float detectionRange = 10f;
    public float attackRange = 1.8f;
    public float attackCooldown = 2f;

    [Header("Ataque")]
    public int damage = 20;

    private float nextAttackTime;

    void Start()
    {
        animator = GetComponent<Animator>();

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("No se encontró ningún objeto con el tag Player");
        }
    }

    void Update()
    {
        if (player == null)
            return;

        float distance = Vector3.Distance(transform.position, player.position);

        // Fuera del rango de detección
        if (distance > detectionRange)
        {
            animator.SetFloat("Speed", 0f);
            return;
        }

        // Mirar al jugador
        Vector3 lookDirection = player.position - transform.position;
        lookDirection.y = 0;

        if (lookDirection != Vector3.zero)
        {
            Quaternion targetRotation =
                Quaternion.LookRotation(lookDirection);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }

        // Perseguir
        if (distance > attackRange)
        {
            transform.position +=
                transform.forward *
                moveSpeed *
                Time.deltaTime;

            animator.SetFloat("Speed", 1f);
        }
        // Atacar
        else
        {
            animator.SetFloat("Speed", 0f);

            if (Time.time >= nextAttackTime)
            {
                animator.SetTrigger("Attack");
                nextAttackTime = Time.time + attackCooldown;
            }
        }
    }

    public void DealDamage()
    {
        if (player == null)
            return;

        float distance =
            Vector3.Distance(transform.position, player.position);

        if (distance > attackRange)
            return;

        PlayerHealth playerHealth =
            player.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }
}