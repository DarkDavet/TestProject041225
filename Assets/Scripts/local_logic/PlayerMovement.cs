using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;

    [Header("Movement Settings")]
    public float speed = 5f;
    public float gravity = -9.81f;
    public float jumpHeight = 1.5f;

    private float verticalVelocity;

    public void Init()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        if (controller != null)
        {
            if (controller.isGrounded)
            {
                verticalVelocity = -2f;
                if (Input.GetButtonDown("Jump"))
                {
                    verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
                }
            }
            else
            {
                verticalVelocity += gravity * Time.deltaTime;
            }

            controller.Move((move * speed + Vector3.up * verticalVelocity) * Time.deltaTime);
        }     
    }
}
