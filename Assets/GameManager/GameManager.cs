using System;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // public int dayNumber = 0;
    // public int finalDay = 7;
    public float maxTimeToFreeze = 1000f;
    public float currentTime = 0f;
    public Journal journal;
    
    public Ending route;
    public bool diedToSeal = false, diedOfHypothermia = false, diedToWater = false;
    public bool died = false;
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

    void Awake()
    {
        Instance = this;
        route = Ending.Neutral;
    }

    public void EndingSequence()
    {
        // uses the journal to calculate the ending obtained
        journal.EvaluateEnding();
    }
    
}
