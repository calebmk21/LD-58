using System;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int dayNumber = 0;
    
    [Header("Inventory and Journal")] 
    [SerializeField] 
    public SerializedDictionary<int, Item> inventoryDictionary = new();


    private void Awake()
    {
        Instance = this;
    }

    public void AnalyzeItem(Item item)
    {
        inventoryDictionary.Add(item.id, item);
    }

    public void NewDay()
    {
        dayNumber += 1;
    }
    
    
    
    
    
}
