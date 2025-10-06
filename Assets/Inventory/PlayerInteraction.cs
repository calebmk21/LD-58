using UnityEngine;
using UnityEngine.InputSystem;


interface IInteractable 
{ 
    public void Interact();
}

public class PlayerInteraction : MonoBehaviour
{

    // public PlayerController _controller;
    public InputAction _interactAction;
    public Backpack inventory;
    
    public bool canInteract, isTriggerAnItem;
    public GameObject currentInteractable;
    
    
    void Awake()
    {
        // _controller = GetComponent<PlayerController>();
        _interactAction = InputSystem.actions.FindAction("Interact");
    }
    
    void Update()
    {
        if (canInteract && _interactAction.IsPressed())
        {
            Debug.Log("Interacted Successfully");
            canInteract = false;
            currentInteractable.TryGetComponent(out IInteractable obj);
            obj.Interact();
        }
        else if (isTriggerAnItem && _interactAction.IsPressed() && inventory.canCarryMore)
        {
            Debug.Log("Collected Item");
            isTriggerAnItem = false;
            currentInteractable.TryGetComponent(out IInteractable obj);
            obj.Interact();
        }
    }
    
    // Handle trigger zones here
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            Debug.Log("In range of Interactable object");
            canInteract = true;
            currentInteractable = other.gameObject;
        }
        else if (other.gameObject.CompareTag("Item"))
        {
            Debug.Log("In range of Item");
            isTriggerAnItem = true;
            currentInteractable = other.gameObject;
        }
        else if (other.gameObject.CompareTag("Warmth"))
        {
            GameManager.Instance.nearWarmth = true;
            Debug.Log("Mmmm warm....");
            GameManager.Instance.bgm.Pause();
            GameManager.Instance.bgm.clip = GameManager.Instance.campsite;
            GameManager.Instance.bgm.Play();
            
        }
        
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            Debug.Log("Leaving range of Interactable object");
            canInteract = false;
            currentInteractable = null;
        }
        else if (other.gameObject.CompareTag("Item"))
        {
            Debug.Log("Leaving range of Item");
            isTriggerAnItem = false;
            currentInteractable = null;
        }
        else if (other.gameObject.CompareTag("Warmth"))
        {
            GameManager.Instance.nearWarmth = false;
            Debug.Log("Leaving Warmth");
            GameManager.Instance.bgm.Pause();
            GameManager.Instance.bgm.clip = GameManager.Instance.mainMusic;
            GameManager.Instance.bgm.Play();
        }
    }
    
}
