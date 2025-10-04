using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class WorldItem : MonoBehaviour, IInteractable
{
    public Item item;
    public bool inInventory = false;
    public GameObject parentObject;
    public UnityEvent onCollect;

    void Awake()
    {
        
    }
    
    public void Interact()
    {
        onCollect.Invoke();
        Destroy(parentObject);
    }
}
