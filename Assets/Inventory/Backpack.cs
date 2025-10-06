using System;
using System.Collections.Generic;
using Unity.VisualScripting;
// using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Backpack : MonoBehaviour
{

    // [Header("References")] 
    // [SerializeField]
    // private BackpackUI ui;
    // private AudioSource _audioSource;

    // [Header("Prefabs")] 
    // [SerializeField] 
    // private GameObject itemInWorld;

    public AudioClip itemGet;
    public AudioSource sfx;
    
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
    
    // [SerializeField]
    public List<List<GameObject>> mittenCounter;

    // List of gameobjects for each UI indicator
    public List<GameObject> mitten1;
    public List<GameObject> mitten2;
    public List<GameObject> mitten3;

    
    [Header("Mitten Assets")] 
    [SerializeField]
    public GameObject baseMitt, occupiedMitt, unavailableMitt;
    
    
    private void Awake()
    {
        sfx.clip = itemGet;
    }

    void Start()
    {
        mitten1[0].SetActive(false);
        mitten1[1].SetActive(true);
        mitten1[2].SetActive(false);
        
        mitten2[2].SetActive(false);
        mitten2[1].SetActive(false);
        mitten2[0].SetActive(true);
        
        mitten3[2].SetActive(false);
        mitten3[1].SetActive(false);
        mitten3[0].SetActive(true);
        
        // hopefully this isn't ncessary
        mittenCounter.Add(mitten1);
        mittenCounter.Add(mitten2);
        mittenCounter.Add(mitten3);
        
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

        if (itemList == null)
        {
            itemList = new();
        }
        

    }

    public void Collect(Item item)
    {

        switch (currentlyCarrying)
        {
            case (0):
                AddItemToMitten(mitten1);
                break;
            case (1):
                AddItemToMitten(mitten2);
                break;
            case (2):
                AddItemToMitten(mitten3);
                break;
            case (3):
                break;
        }
        
        itemList.Add(item);
        currentlyCarrying += 1;
        Debug.Log("Collected Item ID: " + item.id);

        GameManager.Instance.indicationMarker.sprite = GameManager.Instance.inTheCold;
        
        sfx.Play();
    }

    public void AddItemToMitten(List<GameObject> mitt)
    {
        mitt[2].SetActive(true);
        mitt[1].SetActive(false);
        mitt[0].SetActive(false);
    }

    public void BetterBackpackAcquired()
    {
        maxCapacity = 3;
        hasBetterBackpack = true;
        
        mitten2[0].SetActive(false);
        mitten2[1].SetActive(true);
        
        mitten3[0].SetActive(false);
        mitten3[1].SetActive(true);
        
    }

    public void RadarAcquired()
    {
        hasRadar = true;
        RadarPanel.SetActive(true);
    }

    public void ClearMittenUI()
    {
        if (hasBetterBackpack)
        {
            mitten1[1].SetActive(true);
            mitten2[1].SetActive(true);
            mitten3[1].SetActive(true);
            
            mitten1[2].SetActive(false);
            mitten2[2].SetActive(false);
            mitten3[2].SetActive(false);
            
            mitten1[0].SetActive(false);
            mitten2[0].SetActive(false);
            mitten3[0].SetActive(false);
        }

        else
        {
            mitten1[1].SetActive(true);
            mitten2[1].SetActive(false);
            mitten3[1].SetActive(false);
            
            mitten1[2].SetActive(false);
            mitten2[2].SetActive(false);
            mitten3[2].SetActive(false);
            
            mitten2[0].SetActive(true);
            mitten3[0].SetActive(true);
        }
    }
}
