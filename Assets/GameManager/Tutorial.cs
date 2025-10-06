using System.Transactions;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] public AudioSource ambiance;
    [SerializeField] public AudioSource narration;

    public AudioClip windHowl;
    public AudioClip[] tutorialClips;
    public GameObject[] tutorialPanels;

    public GameObject tutorialCanvas;
    
    public GameObject currentPage;
    private int pageNum;
    
    void Awake()
    {
        pageNum = 0;
        narration.clip = tutorialClips[pageNum];
        narration.Play();
        currentPage = tutorialPanels[pageNum];
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
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
    
    public void ViewTutorialAgain()
    {
        Time.timeScale = 0f;
        tutorialCanvas.SetActive(true);
        currentPage.SetActive(false);
        
        pageNum = 0;
        narration.clip = tutorialClips[pageNum];
        narration.Play();
        currentPage = tutorialPanels[pageNum];
        
    }
    public void EndTutorial()
    {
        Time.timeScale = 1f; 
        tutorialCanvas.SetActive(false);
        currentPage.SetActive(false);
        narration.Stop();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

}
