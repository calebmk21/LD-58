using UnityEngine;
using UnityEngine.Events;
using UnityEngine.LightTransport;

public class Workstation : MonoBehaviour, IInteractable
{

    // public UnityEvent onAnalyze;
    // public UnityEvent onBetterBackpack;

    public Backpack inventory;
    public Journal journal;
    //public Radar radar;
    
    public void Analyze()
    {
        for (int i = 0; i < inventory.currentlyCarrying; i++)
        {
            journal.AddItemToJournal(inventory.itemList[i]);
            if (inventory.itemList[i].callsign == "backpack")
            {
                inventory.hasBetterBackpack = true;
                inventory.BetterBackpackAcquired();
;            }
            else if (inventory.itemList[i].callsign == "radar")
            {
                inventory.hasRadar = true;
                inventory.RadarAcquired();
            }
            else if (inventory.itemList[i].callsign == "warm")
            {
                GameManager.Instance.warmItems += 1;
            }

            inventory.currentlyCarrying -= 1;
        }
        inventory.itemList.Clear();
        //radar.collectedAnItem = true;


    }

    public void Interact()
    {
        Analyze();
    }

    
}
