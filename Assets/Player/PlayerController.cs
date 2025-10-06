using System;
using UnityEditor;
//using UnityEditor.Searcher;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _controller;
    
    // basic movement floats
    public float moveSpeed = 10f, lookSpeed = 7f, jumpPower = 5f, gravityForce = -10f;
    public float verticalVelocity, maxVerticalVelocity = -5f;
    public float rotY;
    
    // interactions
    public bool isSprinting = false, isGrounded = true;

    [SerializeField] private GameObject mainCamera;
    
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _controller.detectCollisions = true;
    }

    public void Move(Vector2 movement)
    {
        Vector3 tempMainCameraEuler = mainCamera.transform.eulerAngles;
        mainCamera.transform.eulerAngles = new Vector3(0, mainCamera.transform.eulerAngles.y, mainCamera.transform.eulerAngles.z);

        Vector3 move = mainCamera.transform.forward * movement.y + mainCamera.transform.right * movement.x;
        move *= moveSpeed * Time.deltaTime;
        Quaternion targetRotation = move == Vector3.zero ? transform.rotation : Quaternion.LookRotation(move.normalized, Vector3.up);
        transform.rotation = targetRotation;
        mainCamera.transform.eulerAngles = tempMainCameraEuler;
        _controller.Move(move);

        verticalVelocity += gravityForce * Time.deltaTime;
        Vector3 jumpVec = new Vector3(0, verticalVelocity, 0) * Time.deltaTime;
        _controller.Move(jumpVec);

        if (verticalVelocity < maxVerticalVelocity)
        {
            verticalVelocity = 0f;
        }
        
        // if (!isGrounded)
        // {
        //     verticalVelocity += gravityForce * Time.deltaTime;
        //     Vector3 jumpVec = new Vector3(0, verticalVelocity, 0) * Time.deltaTime;
        //     _controller.Move(jumpVec);
        // }

        // if (isGrounded)
        // {
        //     verticalVelocity = 0f;
        // }
    }

    public void Look(Vector2 looking)
    {
        rotY += looking.x * lookSpeed * Time.deltaTime;
        // transform.localRotation = Quaternion.Euler(0, rotY, 0);
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

    public void OnCollisionEnter(Collision other)
    {
        
        Debug.Log("Entered Collider " + other.gameObject.tag);
        
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            verticalVelocity = 0f;
        }
        
    }

    public void OnCollisionExit(Collision other)
    {
        
        Debug.Log("Entered Collider " + other.gameObject.tag);
        
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    
    

}
