using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class JournalUI : MonoBehaviour
{
    public Journal journal;
    public Dictionary<string, GameObject> progressionPanels;
    //private int indexID = -1;
    void Start()
    { 
        GameObject[] progressionPanelArray = FindObjectsByType<GameObject>(FindObjectsInactive.Include, FindObjectsSortMode.None).Where(sr => sr.CompareTag("Progression")).ToArray();
        for (int i = 0; i < progressionPanelArray.Length; i++)
        {
            progressionPanels.Add(progressionPanelArray[i].name, progressionPanelArray[i]);
        }
        //Debug.Log(progressionPanels);
        Debug.Log(progressionPanelArray[0].name);
        Debug.Log(progressionPanelArray[1].name);
        Debug.Log(progressionPanelArray[2].name);
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void UnlockEntry(string panelName)
    {
        GameObject obj;
        if (progressionPanels.TryGetValue(panelName, out obj))
        {
            Destroy(obj);
            progressionPanels.Remove(panelName);
        }
        
    }



    
}
