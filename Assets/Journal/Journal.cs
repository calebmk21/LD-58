using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Rendering.UI;

public class Journal : MonoBehaviour
{

    public SerializedDictionary<int, Item> inventoryDictionary = new();
    private int fossils = 0, trinkets = 0, tools = 0;
    public int maxFossils = 8;
    public int maxTrinkets, maxTools;

    public JournalUI journalUI;
    public AudioSource sfx;
    public AudioClip journalOpen;
    //public AudioClip pageTurn;
    
    private bool isJournalOpen = false;
    // public InputAction ;

    void Start()
    {
        sfx.clip = journalOpen;
    }

    public void UseJournal()
    {
        isJournalOpen = !isJournalOpen;
        journalUI.gameObject.SetActive(isJournalOpen);
        if (isJournalOpen)
        {
            // pausing game
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            sfx.Play();
        }
        else
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
        }
    }
    
    public void AddItemToJournal(Item item)
    {
        int itemID = item.id;
        inventoryDictionary.Add(itemID, item);
        journalUI.UnlockEntry(item.panelName);
        Debug.Log("Logged " + item.callsign + " to journal");
    }

    public void ComputeNumberOfEachItem()
    {
        foreach (KeyValuePair<int, Item> entry in inventoryDictionary)
        {
            Item item = entry.Value;
            if (item.tag == ItemTag.Trinket)
            {
                trinkets += 1;
            }
            else if (item.tag == ItemTag.Tool)
            {
                tools += 1;
            }
            else if (item.tag == ItemTag.Artifact)
            {
                fossils += 1;
            }
        }
    }

    // public ItemTag RankItemTag()
    // {
    //     if (trinkets > fossils && trinkets > tools)
    //     {
    //         return ItemTag.Trinket;
    //     }
    //     
    //     
    //     
    //     else
    //     {
    //         return ItemTag.Tool;
    //     } 
    // }
    
    public void EvaluateEnding()
    {
        ComputeNumberOfEachItem();

        GameManager.Ending ending;

        // You died.
        if (GameManager.Instance.died)
        {
            ending = GameManager.Ending.Dead;
        }
        else if (trinkets == maxTrinkets && tools == maxTools)
        {
            ending = GameManager.Ending.Detective;
        }
        
        // Conference ending is achieved if you get all fossils or at least 4 fossils and few trinkets and tools
        else if (fossils == maxFossils || (fossils > 4 && trinkets + tools < 2) )
        {
            ending = GameManager.Ending.Conference;
        }
        
        else if (tools + fossils + trinkets == 0)
        {
            ending = GameManager.Ending.Coward;
        }
        
        else
        {
            ending = GameManager.Ending.Neutral;
        }
        
        GameManager.Instance.UpdateEnding(ending);
    }
}
