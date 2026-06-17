using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingWater : MonoBehaviour
{
    public float riseSpeed = 0.2f;

    void Update()
    {
        transform.position += Vector3.up * riseSpeed * Time.deltaTime;
    }
}
