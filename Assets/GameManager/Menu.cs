using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{

    public GameObject thisPanel;
    
    // this plays the next audio clip in the tutorial
    public AudioSource nextAudio;
    
    
    public void ChangeScene(string newScene)
    {
        SceneManager.LoadScene(newScene);
    }

    public void MenuToggle(GameObject newPanel)
    {
        thisPanel.SetActive(false);
        newPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ToggleBrooklynSealMode()
    {
        GameManager.Instance.calvinFuckingLosesIt = !GameManager.Instance.calvinFuckingLosesIt;
    }
    
    // public void TutorialSequence()
    // {
    //     
    //     thisPanel.SetActive(false);
    //     nextAudio.Play();
    // }
    
    
}
