using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Backpack : MonoBehaviour
{

    [Header("References")] 
    [SerializeField]
    private BackpackUI ui;
    private AudioSource _audioSource;

    [Header("Prefabs")] 
    [SerializeField] 
    private GameObject itemInWorld;

    [Header("Dict")] 
    [SerializeField] 
    private SerializedDictionary<int, Item> inventoryDictionary = new();
    public List<Item> Inventory { get; set; }

    private void Awake()
    {
        Inventory = new List<Item>();
    }

    public void Collect(Item item)
    {
        inventoryDictionary.Add(item.id, item);
        Inventory.Add(item);
    }
}
