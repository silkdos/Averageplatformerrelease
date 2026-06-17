using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    public Transform target;

    public float speed = 70f;
    public float turnSpeed = 3f;

    public int damage = 20;

    public GameObject explosionPrefab;

    void Start()
    {
        Destroy(gameObject, 10f);
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject, 2f);
            return;
        }

        Vector3 direction =
            target.position -
            transform.position;

        Quaternion targetRotation =
            Quaternion.LookRotation(direction);

        transform.rotation =
            Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                turnSpeed * Time.deltaTime
            );

        transform.position +=
            transform.forward *
            speed *
            Time.deltaTime;
    }

    private void OnCollisionEnter(Collision col)
    {

        EnemyShipHealth ship =
            col.collider.GetComponentInParent<EnemyShipHealth>();

        if (ship != null)
        {
            ship.TakeDamage(damage);
        }

        Explode();
    }

    void Explode()
    {
        if (explosionPrefab != null)
        {
            Instantiate(
                explosionPrefab,
                transform.position,
                Quaternion.identity
            );
        }

        Destroy(gameObject);
    }
}