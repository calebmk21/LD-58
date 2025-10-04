using UnityEngine;
using UnityEngine.InputSystem;


interface IInteractable 
{ 
    public void Interact();
}

public class PlayerInteraction : MonoBehaviour
{

    public PlayerController _controller;
    public InputAction _interactAction;
    void Awake()
    {
        _controller = GetComponent<PlayerController>();
        _interactAction = InputSystem.actions.FindAction("Interact");
    }
    
    void Update()
    {
        if (_controller.canInteract && _interactAction.IsPressed())
        {
            Debug.Log("Interacted Successfully");
            _controller.canInteract = false;
        }
        else if (_controller.isTriggerAnItem && _interactAction.IsPressed())
        {
            Debug.Log("Collected Item");
            _controller.isTriggerAnItem = false;
        }
    }
    
    
    
}
