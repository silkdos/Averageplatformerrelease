using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("Ataque")]
    public int damage = 20;
    public int betterdamage;
    public float attackRange = 2f;
    public float attackCooldown = 0.8f;

    private Animator animator;
    private float nextAttackTime;

    public void ApplyDamageUpgrade(int multiplier)
    {
        betterdamage = damage + multiplier;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Time.time < nextAttackTime)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    private void Attack()
    {
        animator.SetTrigger("Attack");

        nextAttackTime =
            Time.time + attackCooldown;
    }

    // Se llamará desde un Animation Event
    public void DealDamage()
    {
        Collider[] hitEnemies =
            Physics.OverlapSphere(
                transform.position + transform.forward * attackRange * 0.5f,
                attackRange
            );

        foreach (Collider hit in hitEnemies)
        {
            EnemyHealth enemyHealth =
                hit.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(betterdamage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(
            transform.position + transform.forward * attackRange * 0.5f,
            attackRange
        );
    }
}