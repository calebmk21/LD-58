using UnityEngine;

public class SplashSound : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip splashClip;

    private float startTimer = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer > 0)
            startTimer -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Splash on trigger enter");
        if (startTimer > 0)
            return;
        if (other.gameObject.tag == "Seal" || other.gameObject.tag == "Player")
            audioSource.PlayOneShot(splashClip, 0.01f);
    }
}
