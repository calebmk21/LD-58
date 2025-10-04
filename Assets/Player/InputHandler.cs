using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

public class InputHandler : MonoBehaviour
{
    public PlayerController controller;
    
    // Input Actions initialized to be assigned at Start
    private InputAction _moveAction, _lookAction, _jumpAction, _sprintAction, _interactAction;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
        _lookAction = InputSystem.actions.FindAction("Look");
        _jumpAction = InputSystem.actions.FindAction("Jump");
        _sprintAction = InputSystem.actions.FindAction("Sprint");
        _interactAction = InputSystem.actions.FindAction("Interact");

        _jumpAction.performed += OnJumpPerformed;
        _sprintAction.performed += OnSprintPerformed;
        _interactAction.performed += OnInteractPerformed;
        
        Cursor.visible = false;
    }

    // Passing inputs to CharacterController object
    void Update()
    {
        Vector2 CharacterMovement = _moveAction.ReadValue<Vector2>();
        controller.Move(CharacterMovement);

        Vector2 SightlineVector = _lookAction.ReadValue<Vector2>();
        controller.Look(SightlineVector);
        
    }

    private void OnJumpPerformed(InputAction.CallbackContext context)
    {
        controller.Jump();
    }

    private void OnSprintPerformed(InputAction.CallbackContext context)
    {
        controller.Sprint();
    }

    private void OnInteractPerformed(InputAction.CallbackContext context)
    {
        controller.Interact();
    }

}