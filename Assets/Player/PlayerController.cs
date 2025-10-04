using System;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _controller;

    // basic movement floats
    public float moveSpeed = 10f, lookSpeed = 7f, jumpPower = 5f, gravityForce = -10f;
    public float verticalVelocity;
    public float rotY;

    public bool isSprinting = false, isGrounded = true;

    public bool canInteract = false;
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _controller.detectCollisions = true;
    }

    public void Move(Vector2 movement)
    {
        Vector3 move = transform.forward * movement.y + transform.right * movement.x;
        move *= moveSpeed * Time.deltaTime;
        _controller.Move(move);
        verticalVelocity += gravityForce * Time.deltaTime;
        Vector3 jumpVec = new Vector3(0, verticalVelocity, 0) * Time.deltaTime;
        _controller.Move(jumpVec);

        if (isGrounded)
        {
            verticalVelocity = 0f;
        }
    }

    public void Look(Vector2 looking)
    {
        rotY += looking.x * lookSpeed * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(0, rotY, 0);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            verticalVelocity = jumpPower;
            isGrounded = false;
        }
        else
        {
            Debug.Log("Not grounded, cannot jump");
        }
    }

    public void Sprint()
    {
        if (!isSprinting)
        {
            Debug.Log("Sprinting");
            moveSpeed *= 1.7f;
            isSprinting = true;
        }
        else
        {
            Debug.Log("Not Sprinting");
            moveSpeed /= 1.7f;
            isSprinting = false;
        }
    }

    public void Interact()
    {
        int interactionCounter = 0;
        
        if (canInteract)
        {
            interactionCounter += 1;
            Debug.Log("Interacted!");
            Debug.Log(interactionCounter);
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        
        Debug.Log("Entered Collider " + other.gameObject.tag);
        
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            verticalVelocity = 0f;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            Debug.Log("In range of Interactable object");
            canInteract = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            Debug.Log("Leaving range of Interactable object");
            canInteract = false;
        }
    }
}
