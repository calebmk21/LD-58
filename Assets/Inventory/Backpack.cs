using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class Backpack : MonoBehaviour
{

    // [Header("References")] 
    // [SerializeField]
    // private BackpackUI ui;
    // private AudioSource _audioSource;

    // [Header("Prefabs")] 
    // [SerializeField] 
    // private GameObject itemInWorld;

    [Header("Upgrades")] 
    [SerializeField] 
    private int maxCapacity = 1;
    public int currentlyCarrying = 0;
    public bool canCarryMore = true;
    public bool hasRadar = false, hasBetterBackpack = false;
    // public UnityEvent onBetterBackpack, onRadarAcquired;
    public GameObject RadarPanel;
    
    [Header("Inventory")]
    [SerializeField]
    public GameObject newItem;
    public List<Item> itemList;
    public Journal journal;
    
    
    private void Awake()
    {

    }

    void Update()
    {
        if (currentlyCarrying < maxCapacity)
        {
            canCarryMore = true;
        }
        else
        {
            canCarryMore = false;
        }


    }

    public void Collect(Item item)
    {
        itemList.Add(item);
        currentlyCarrying += 1;
        Debug.Log("Collected Item ID: " + item.id);
    }

    public void BetterBackpackAcquired()
    {
        maxCapacity = 3;
    }

    public void RadarAcquired()
    {
        hasRadar = true;
        RadarPanel.SetActive(true);
    }
    
}
