using UnityEngine;
using System.Collections;

public class EnemyBulletLand : MonoBehaviour
{
    public GameObject explo;

    public int damage = 2;

    public float explosionRadius = 5f;

    void OnCollisionEnter(Collision col)
    {
        Vector3 explosionPoint = col.contacts[0].point;

        Collider[] hitColliders =
            Physics.OverlapSphere(
                explosionPoint,
                explosionRadius
            );

        foreach (Collider hit in hitColliders)
        {
            PlayerHealth player =
                hit.GetComponentInParent<PlayerHealth>();

            if (player != null)
            {
                player.TakeDamage(damage);
            }

            EnemyHealth enemy =
                hit.GetComponentInParent<EnemyHealth>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }

        Instantiate(
            explo,
            explosionPoint,
            Quaternion.identity
        );

        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(
            transform.position,
            explosionRadius
        );
    }
}
