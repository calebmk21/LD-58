using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

public class InputHandler : MonoBehaviour
{

    public GameObject fireball; 
    
    public PlayerController controller;
    
    private InputAction _moveAction, _lookAction, _jumpAction, _attackAction;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
        _lookAction = InputSystem.actions.FindAction("Look");
        _jumpAction = InputSystem.actions.FindAction("Jump");
        _attackAction = InputSystem.actions.FindAction("Attack");

        _jumpAction.performed += OnJumpPerformed;
        _attackAction.performed += OnAttackPerformed;
        
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

    private void OnAttackPerformed(InputAction.CallbackContext context)
    {
        Debug.Log("Attacking");
        controller.Attack(PlayerManager.Instance.attackMode);
    }
}
