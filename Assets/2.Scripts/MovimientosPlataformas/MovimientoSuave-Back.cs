using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformBack : MonoBehaviour
{
    public float altura = 3f;     // cuánto sube y baja
    public float velocidad = 1f;  // velocidad del movimiento

    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        float movimiento = Mathf.PingPong(Time.time * velocidad, altura);

        transform.position = posicionInicial + Vector3.back * movimiento;
    }
}
