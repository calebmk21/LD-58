using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class JournalUI : MonoBehaviour
{
    public Journal journal;
    public Dictionary<string, GameObject> progressionPanels =  new();
    //private int indexID = -1;
    void Start()
    { 
        GameObject[] progressionPanelArray = FindObjectsByType<GameObject>(FindObjectsInactive.Include, FindObjectsSortMode.None).Where(sr => sr.CompareTag("Progression")).ToArray();
        
        //Debug.Log(progressionPanels);
        // Debug.Log(progressionPanelArray[0].name);
        // Debug.Log(progressionPanelArray[1].name);
        // Debug.Log(progressionPanelArray[2].name);
        
        for (int i = 0; i < progressionPanelArray.Length; i++)
        {
            string panelName = progressionPanelArray[i].name;
            GameObject obj = progressionPanelArray[i];
            // Debug.Log("Adding prog panel " + panelName);
            // Debug.Log("Adding panel " + obj);
            progressionPanels.Add(panelName, obj);
        }

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
