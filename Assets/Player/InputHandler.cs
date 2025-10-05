using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using UnityEngine.TextCore.Text;

public class InputHandler : MonoBehaviour
{
    public PlayerController controller;
    public Backpack inventory;
    public WorldItem nearbyItem;
    public bool inRangeOfItem = false;

    public Journal journal;

    [SerializeField] private Animator animator;
    
    // Input Actions initialized to be assigned at Start
    private InputAction _moveAction, _lookAction, _jumpAction, _sprintAction, _interactAction, _journalAction;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
        _lookAction = InputSystem.actions.FindAction("Look");
        _jumpAction = InputSystem.actions.FindAction("Jump");
        _sprintAction = InputSystem.actions.FindAction("Sprint");
        _interactAction = InputSystem.actions.FindAction("Interact");
        _journalAction = InputSystem.actions.FindAction("Journal");

        _jumpAction.performed += OnJumpPerformed;
        _sprintAction.performed += OnSprintPerformed;
        _interactAction.performed += OnInteractPerformed;
        _journalAction.performed += OnJournalPerformed;
        
        Cursor.visible = false;
    }

    // Passing inputs to CharacterController object
    void Update()
    {
        Vector2 CharacterMovement = _moveAction.ReadValue<Vector2>();
        if (CharacterMovement != Vector2.zero)
            animator.SetBool("Move", true);
        else
            animator.SetBool("Move", false);
        controller.Move(CharacterMovement);

        Vector2 SightlineVector = _lookAction.ReadValue<Vector2>();
        controller.Look(SightlineVector);
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            nearbyItem = other.gameObject.GetComponent<WorldItem>();
            inRangeOfItem = true;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            nearbyItem = null;
            inRangeOfItem = false;
        }
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
        if (inRangeOfItem && nearbyItem != null)
        {
            // inventory.Collect();
        }
    }

    private void OnJournalPerformed(InputAction.CallbackContext context)
    {
        journal.UseJournal();
    }

}