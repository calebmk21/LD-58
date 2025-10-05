using System.Collections.Generic;
using UnityEngine;

public class PageNavigator : MonoBehaviour
{
    public GameObject thisPage;
    public GameObject testDelete;
    public List<GameObject> progressionPanels;
    
    public void ChangePage(GameObject nextPage)
    {
        nextPage.SetActive(true);
        thisPage.SetActive(false);
    }


    
    public void DeleteGameObject(GameObject obj)
    {
        Destroy(testDelete);
    }
}
