using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.UI;

public class Journal : MonoBehaviour
{

    public SerializedDictionary<string, Item> inventoryDictionary = new();
    
    public void AddItemToJournal(Item item)
    {
        inventoryDictionary.Add(item.id, item);
        Debug.Log("Logged " + item.id + " to journal");
    }
}
