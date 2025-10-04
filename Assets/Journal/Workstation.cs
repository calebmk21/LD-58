using UnityEngine;
using UnityEngine.Events;
using UnityEngine.LightTransport;

public class Workstation : MonoBehaviour, IInteractable
{

    // public UnityEvent onAnalyze;
    // public UnityEvent onBetterBackpack;

    public Backpack inventory;
    public Journal journal;
    
    public void Analyze()
    {
        for (int i = 0; i < inventory.currentlyCarrying; i++)
        {
            journal.AddItemToJournal(inventory.itemList[i]);
            if (inventory.itemList[i].id == "backpack")
            {
                inventory.hasBetterBackpack = true;
                inventory.BetterBackpackAcquired();
;            }
            else if (inventory.itemList[i].id == "radar")
            {
                inventory.hasRadar = true;
            }

            inventory.currentlyCarrying -= 1;
            
        }

        
    }

    public void Interact()
    {
        Analyze();
    }

    
}
