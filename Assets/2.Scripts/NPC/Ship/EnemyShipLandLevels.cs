using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipAILand : MonoBehaviour
{
    public Transform target;

    public float moveSpeed = 50f;
    public float rotationSpeed = 1f;
    public float attackDistance = 250f;
    public float retreatDistance = 50f;

    public float retreatTime = 5f;

    private bool retreating = false;
    private float retreatTimer = 0f;

    private Vector3 retreatDirection;

    private Rigidbody rb;

    public GameObject bulletPrefab;
    public Transform firePoint1;
    public Transform firePoint2;

    public float fireRate = 0.2f;

    private float nextFireTime;

    [Header("Audio")]
    public AudioSource engineAudioSource;
    public AudioClip engineLoop;

    public AudioSource weaponAudioSource;
    public AudioClip laserSound;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (engineAudioSource != null && engineLoop != null)
        {
            engineAudioSource.clip = engineLoop;
            engineAudioSource.loop = true;
            engineAudioSource.Play();
        }

        if (target == null)
        {
            GameObject player =
                GameObject.FindGameObjectWithTag("Player");

            if (player != null)
            {
                target = player.transform;
            }
        }
    }

    private void FixedUpdate()
    {
        if (target == null)
            return;

        Vector3 direction =
    (target.position - transform.position)
    .normalized;

        Quaternion targetRotation =
            Quaternion.LookRotation(direction);

        transform.rotation =
            Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );

        rb.velocity =
            transform.forward * moveSpeed;

        float distance =
            Vector3.Distance(
                transform.position,
                target.position
            );

        if (retreating)
        {
            retreatTimer -= Time.deltaTime;

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(retreatDirection),
                rotationSpeed * Time.deltaTime
            );

            rb.velocity =
                transform.forward * moveSpeed;

            if (retreatTimer <= 0)
            {
                retreating = false;
            }

            return;
        }

        if (distance < retreatDistance)
        {
            StartRetreat();

            return;
        }

        if (distance <= attackDistance)
        {
            AttackMovement();

            if (Time.time >= nextFireTime)
            {
                Shoot();

                nextFireTime =
                    Time.time + fireRate;
            }

            return;
        }


    }

    void AttackMovement()
    {
        Vector3 direction =
            (target.position - transform.position)
            .normalized;

        Quaternion targetRotation =
            Quaternion.LookRotation(direction);

        transform.rotation =
            Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
    }

    void StartRetreat()
    {
        retreating = true;

        retreatTimer = retreatTime;

        Vector3 awayFromPlayer =
            (transform.position - target.position).normalized;

        retreatDirection =
            awayFromPlayer + Vector3.up;

        retreatDirection.Normalize();
    }

    void Shoot()
    {
        if (weaponAudioSource != null &&
            laserSound != null)
        {
            weaponAudioSource.PlayOneShot(laserSound);
        }

        FireFromPoint(firePoint1);
        FireFromPoint(firePoint2);
    }

    void FireFromPoint(Transform point)
    {
        if (point == null)
            return;

        GameObject bullet =
            Instantiate(
                bulletPrefab,
                point.position,
                point.rotation
            );

        Rigidbody rb =
            bullet.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.AddForce(
                point.forward * 200f
            );
        }
    }
}