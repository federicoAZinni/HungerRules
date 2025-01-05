using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 3.0f;
    public float currentSpeed;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift)) playerSpeed = Mathf.Lerp(playerSpeed,5,Time.deltaTime*5);
        else playerSpeed = Mathf.Lerp(playerSpeed, 3, Time.deltaTime * 5);

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        playerVelocity.y += -9.8f * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        currentSpeed = Mathf.Clamp01(move.magnitude) * playerSpeed;
    }
}


