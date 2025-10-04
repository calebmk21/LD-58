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

    [Header("Upgrades")] 
    [SerializeField] 
    private int maxCapacity = 1;
    private int currentlyCarrying = 0;
    private bool canCarryMore = true;

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

    public void Collect()
    {
        
    }
    
}
