using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class WorldItem : MonoBehaviour
{
    public Item item;
    public bool inInventory = false;

    public UnityEvent onCollect;

    public void Collect()
    {
        onCollect.Invoke();
    }

}
