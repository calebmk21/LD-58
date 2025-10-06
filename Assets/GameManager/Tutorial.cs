using System.Transactions;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] public AudioSource ambiance;
    [SerializeField] public AudioSource narration;

    public AudioClip windHowl;
    public AudioClip[] tutorialClips;
    public GameObject[] tutorialPanels;

    public GameObject currentPage;
    private int pageNum;
    
    void Awake()
    {
        pageNum = 0;
        narration.clip = tutorialClips[pageNum];
        narration.Play();
        currentPage = tutorialPanels[pageNum];
    }
    
    // i should probably add failsafes in case you go out of bounds... nah
    
    public void NextPage()
    {
        // disables current page, stops narration
        currentPage.SetActive(false);
        narration.Stop();
        
        // increments page 
        pageNum += 1;
        
        // shifts page up
        narration.clip = tutorialClips[pageNum];
        currentPage = tutorialPanels[pageNum];
        
        // displays next page and plays next clip
        narration.Play();
        currentPage.SetActive(true);
    }

    public void PreviousPage()
    {
        // disables current page, stops narration
        currentPage.SetActive(false);
        narration.Stop();
        
        // decrements page 
        pageNum -= 1;
        
        // shifts page down
        narration.clip = tutorialClips[pageNum];
        currentPage = tutorialPanels[pageNum];
        
        // displays previous page and plays previous clip
        narration.Play();
        currentPage.SetActive(true);
    }


}
