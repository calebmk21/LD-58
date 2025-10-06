using UnityEngine;

public class UIPopups : MonoBehaviour
{
    public GameObject panel;
    

    void EndTheGame()
    {
        GameManager.Instance.EndingSequence();
    }

    void CloseWindow()
    {
        panel.SetActive(false);
    }
    
    
}
