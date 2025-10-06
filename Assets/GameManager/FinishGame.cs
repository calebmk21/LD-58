using UnityEngine;
using UnityEngine.Events;
// using UnityEngine.LightTransport;

public class FinishGame : MonoBehaviour, IInteractable
{

    public GameObject endConfirmation;
    
    public void EndGameConfirmation()
    {
        endConfirmation.SetActive(true);

        Time.timeScale = 0f;
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Interact()
    {
        EndGameConfirmation();
    }

    public void ContinueGame()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        
        endConfirmation.SetActive(false);
    }

    public void EndGame()
    {
        GameManager.Instance.EndingSequence();
    }

    
}