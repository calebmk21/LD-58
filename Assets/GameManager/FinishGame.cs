using UnityEngine;
using UnityEngine.Events;
using UnityEngine.LightTransport;

public class FinishGame : MonoBehaviour, IInteractable
{

    public GameObject endConfirmation;
    
    public void EndGame()
    {
        endConfirmation.SetActive(true);
    }

    public void Interact()
    {
        EndGame();
    }

    
}