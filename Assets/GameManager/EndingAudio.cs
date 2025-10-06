using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingAudio : MonoBehaviour
{
    public AudioSource source;
    public AudioClip endNarr;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        source.clip = endNarr;
        source.Play();
    }

    public void GoBackToTitle()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void GoToGame()
    {
        SceneManager.LoadScene("TerrainScene");
    }
    
}
