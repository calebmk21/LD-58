using System;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int dayNumber = 0;
    public int finalDay = 7;

    public enum Ending
    {
        Neutral,
        Conference,
        Detective,
        Dead
    }
    


    private void Awake()
    {
        Instance = this;
    }

    // public void AnalyzeItem(Item item)
    // {
    //     inventoryDictionary.Add(item.id, item);
    // }

    public void NewDay()
    {
        dayNumber += 1;
    }
    
    
    
    
    
}
