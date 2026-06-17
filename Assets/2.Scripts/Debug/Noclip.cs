using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class DebugFly : MonoBehaviour
{
    public float flySpeed = 10f;
    public KeyCode toggleKey = KeyCode.F;

    private CharacterController controller;
    private ThirdPersonController thirdPersonController;

    private bool flying = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        thirdPersonController = GetComponent<ThirdPersonController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            flying = !flying;

            thirdPersonController.enabled = !flying;

            Debug.Log("Fly Mode: " + flying);
        }

        if (flying)
        {
            FlyMovement();
        }
    }

    void FlyMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (Input.GetKey(KeyCode.Space))
        {
            move += Vector3.up;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            move += Vector3.down;
        }

        controller.Move(move * flySpeed * Time.deltaTime);
    }
}