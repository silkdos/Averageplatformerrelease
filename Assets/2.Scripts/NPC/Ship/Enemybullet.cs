using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour
{

    public GameObject explo;

    public int damage = 5;

    void OnCollisionEnter(Collision col)
    {

        ShipHealth ship =
        col.collider.GetComponentInParent<ShipHealth>();

   

        if (ship != null)
        {
            ship.TakeDamage(damage);

            Debug.Log(
                "Daño aplicado a " +
                ship.name
            );
        }

        Instantiate(
            explo,
            col.contacts[0].point,
            Quaternion.identity
        );

        Destroy(gameObject);
    }




}
