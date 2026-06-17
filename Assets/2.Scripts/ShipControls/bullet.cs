using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {

	public GameObject explo;

    public int damage = 5;

    void OnCollisionEnter(Collision col) {

        EnemyShipHealth ship =
        col.collider.GetComponentInParent<EnemyShipHealth>();
        
        RockHealth rock =
        col.collider.GetComponentInParent<RockHealth>();


        if (ship != null)
        {
            ship.TakeDamage(damage);

            Debug.Log(
                "Daño aplicado a " +
                ship.name
            );
        }
        else
        {
            rock.TakeDamage(damage);
        }

            Instantiate(
            explo,
            col.contacts[0].point,
            Quaternion.identity
        );

        Destroy(gameObject);
    }




}