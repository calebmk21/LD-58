using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;
    public GameObject pauseMenuPanel;
    public GameObject settingsPanel;

    // public AudioMixer audioMixer;
    public Slider volumeSlider;
    public Slider sfxSlider;

    public AudioSource bgm;
    public AudioSource sfx;

    public Tutorial tutorial;
    
    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        pauseCanvas.SetActive(true);
    }

    public void ResumeGame()
    {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    public void GoToSettings()
    {
        
        pauseMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }
    
    public void GoToPause()
    {
        settingsPanel.SetActive(false);
        pauseMenuPanel.SetActive(true);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ToggleBrooklynSealMode()
    {
        GameManager.Instance.calvinFuckingLosesIt = !GameManager.Instance.calvinFuckingLosesIt;
    }

    public void UpdateVolume(Slider slider)
    {
        // audioMixer.SetFloat(slider.value);
    }

    public void ReplayTutorial()
    {
        tutorial.ViewTutorialAgain();
    }
    
}
