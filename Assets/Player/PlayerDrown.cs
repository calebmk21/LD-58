using UnityEngine;
using System.Collections;

public class PlayerDrown : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");

        if (other.gameObject.tag == "Water")
        {
            StartCoroutine(Drown());
        }
    }

    IEnumerator Drown()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Drowned in water");

        GameManager.Instance.died = true;
        GameManager.Instance.diedOfHypothermia = true;
        GameManager.Instance.EndingSequence();
    }
}
