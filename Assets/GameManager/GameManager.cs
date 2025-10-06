using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // public int dayNumber = 0;
    // public int finalDay = 7;
    public float maxTimeToFreeze = 1000f;
    public float currentTime;
    public Journal journal;
    
    public Ending route;
    public bool diedToSeal = false, diedOfHypothermia = false;//, diedToWater = false;
    public bool died = false, nearWarmth = false;

    public int warmItems = 0, maxWarmItems = 5;

    public GameObject tutorialPanel;

    public bool calvinFuckingLosesIt;
    
    public Slider freezeMeter;
    
    public AudioSource bgm;
    public AudioSource sfx;

    // public AudioSource sealAudio;
    
    public AudioClip mainMusic;
    public AudioClip seal;
    public AudioClip sealButFromBrooklyn;
    public AudioClip campsite;

    public JournalUI journalUI;

    public bool isSealChasing;
    
    //public AudioClip pageturn;
    
    public Sprite itemInRange;
    public Sprite inTheCold;
    public Sprite ouch;
    public Sprite canAnalyze;
    public Sprite leavingTime;
    //public Sprite currentSprite;
    public Sprite emptyIndicator;
    
    public Image indicationMarker;
    
    void Awake()
    {
        Instance = this;
        route = Ending.Neutral;

        //currentSprite = null;
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        OpeningSequence();
    }
    
    void Start()
    {
        currentTime = maxTimeToFreeze;
        freezeMeter.value = maxTimeToFreeze;
        bgm.clip = mainMusic;
        bgm.loop = true;
        
        // can comment this out if journal is already active in hierarchy (preferable) 
        journalUI.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        if (freezeMeter.value == 0f)
        {
            died = true;
            diedOfHypothermia = true;
            EndingSequence();
        }
        else if (!nearWarmth)
        {
            // meter depletes slower the more warm items you have
            freezeMeter.value -= 4 * (maxWarmItems - warmItems) * Time.deltaTime;
        }
        // being near warmth brings your warmth meter back up
        else if (nearWarmth && !died)
        {
           
            if (freezeMeter.value < maxTimeToFreeze)
            {
                freezeMeter.value += 10 * (1 + warmItems) * Time.deltaTime;
            }
            else
            {
                freezeMeter.value = maxTimeToFreeze;
            }
        }
    }

    public void OpeningSequence()
    {
        // Tutorial sequence
        Time.timeScale = 0f;
        tutorialPanel.SetActive(true);
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    
    
    
    
    public enum Ending
    {
        Neutral,
        Conference,
        Detective,
        Dead,
        Coward
    }

    public void UpdateEnding(Ending newEnding)
    {
        switch (newEnding)
        {
            case (Ending.Neutral):
                route = Ending.Neutral;
                break;
            case (Ending.Conference):
                route = Ending.Conference;
                break;
            case (Ending.Detective):
                route = Ending.Detective;
                break;
            case (Ending.Dead):
                route = Ending.Dead;
                break;
            case (Ending.Coward):
                route = Ending.Coward;
                break;
        }
    }

    public void EndingSequence()
    {
        
        // maybe add a fade to black? 
        
        // uses the journal to calculate the ending obtained
        journal.EvaluateEnding();
        
        // transition to ending scenes
        string endingString = "FailsafeEnding";

        switch (route)
        {
            case (Ending.Neutral):
                endingString = "NeutralEnding";
                break;
            case (Ending.Conference):
                endingString = "ConferenceEnding";
                break;
            case (Ending.Detective):
                endingString = "DetectiveEnding";
                break;
            case (Ending.Dead):
                if (diedToSeal)
                {
                    endingString = "SealEnding";
                }
                else if (diedOfHypothermia)
                {
                    endingString = "FrozenEnding";
                }
                else
                {
                    endingString = "FailsafeEnding";
                }
                break;
            case (Ending.Coward):
                endingString = "CowardEnding";
                break;
        }

        
        // Debug.Log("You died of hypothermia");
        SceneManager.LoadScene(endingString);

    }
    
}
