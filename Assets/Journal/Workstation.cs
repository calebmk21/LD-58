using UnityEngine;

public class Workstation : MonoBehaviour
{


    public void Analyze(Item item)
    {
        GameManager.Instance.AnalyzeItem(item);
        Debug.Log(item.description);
    }

}
