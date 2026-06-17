using System.Collections;
using StarterAssets;
using UnityEngine;

public class DashPlatform : MonoBehaviour
{
    [Header("Movimiento")]
    public Vector3 direccion = Vector3.back;
    public float distancia = 10f;

    [Header("Velocidades")]
    public float velocidadIda = 30f;
    public float velocidadVuelta = 2f;

    [Header("Tiempos")]
    public float pausaFinal = 1f;
    public float pausaInicio = 3f;

    [Header("Detección jugador")]
    public Vector3 tamañoDeteccion = new Vector3(3f, 0.5f, 3f);
    public float alturaDeteccion = 1f;

    private Vector3 posicionInicial;
    private Vector3 posicionFinal;
    private Vector3 ultimaPosicion;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        posicionInicial = transform.position;
        posicionFinal = posicionInicial + direccion.normalized * distancia;
        ultimaPosicion = transform.position;
        StartCoroutine(MoverRutina());
    }

    IEnumerator MoverRutina()
    {
        while (true)
        {
            yield return new WaitForSeconds(pausaInicio);

            while (Vector3.Distance(transform.position, posicionFinal) > 0.05f)
            {
                Vector3 nuevaPos = Vector3.MoveTowards(
                    transform.position, posicionFinal, velocidadIda * Time.fixedDeltaTime);
                rb.MovePosition(nuevaPos);
                yield return new WaitForFixedUpdate();
            }

            yield return new WaitForSeconds(pausaFinal);

            while (Vector3.Distance(transform.position, posicionInicial) > 0.05f)
            {
                Vector3 nuevaPos = Vector3.MoveTowards(
                    transform.position, posicionInicial, velocidadVuelta * Time.fixedDeltaTime);
                rb.MovePosition(nuevaPos);
                yield return new WaitForFixedUpdate();
            }
        }
    }

    void FixedUpdate()
    {
        Vector3 movimiento = transform.position - ultimaPosicion;
        movimiento.y = 0f;

        ultimaPosicion = transform.position;

        if (movimiento.sqrMagnitude < 0.00001f) return;

        // Detectar jugador en el área lateral/superior
        Collider[] hits = Physics.OverlapBox(
            transform.position + Vector3.up * alturaDeteccion,
            tamañoDeteccion
        );

        foreach (Collider hit in hits)
        {
            // Buscar CharacterController en el objeto o sus padres
            CharacterController cc = hit.GetComponentInParent<CharacterController>();
            if (cc == null) continue;

            // Mover exactamente lo que se movió la plataforma (sin multiplicadores)
            cc.Move(movimiento);
        }
    }
}