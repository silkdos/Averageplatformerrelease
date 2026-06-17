using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1;

    public AudioClip collectSound;

    void Update()
    {
        transform.Rotate(0, 0, 100 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth player = other.GetComponent<PlayerHealth>();

        if (player != null)
        {
            CoinManager.instance.AddCoin(value);

            AudioSource.PlayClipAtPoint(
                collectSound,
                transform.position,
                0.5f
            );

            Destroy(gameObject);
        }
    }
}