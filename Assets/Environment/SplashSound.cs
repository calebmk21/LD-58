using UnityEngine;

public class SplashSound : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip splashClip;

    //[SerializeField] private AudioSource sealAudioSource;

    //private AudioClip sealTerrorAudio;
    
    private float startTimer = 2f;

    private bool isPlayingAudio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //isPlayingAudio = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer > 0)
            startTimer -= Time.deltaTime;

        // if (GameManager.Instance.calvinFuckingLosesIt)
        // {
        //     sealTerrorAudio = GameManager.Instance.sealButFromBrooklyn;
        // }
        // else
        // {
        //     sealTerrorAudio = GameManager.Instance.seal;
        // }
        //
        // sealAudioSource.clip = sealTerrorAudio;
        // sealAudioSource.volume = 0.3f;

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Splash on trigger enter");
        if (startTimer > 0)
            return;
        if (other.gameObject.tag == "Seal" || other.gameObject.tag == "Player")
            audioSource.PlayOneShot(splashClip, 0.01f);

        // if (other.gameObject.CompareTag("Seal"))
        // {
        //     if (!isPlayingAudio)
        //     {
        //         // sealAudioSource.Play();
        //         isPlayingAudio = true;
        //         
        //         sealAudioSource.PlayOneShot(sealTerrorAudio, 0.3f);
        //         
        //     }
        // }

        if (isPlayingAudio)
        {
            // sealAudioSource.Pause();
            isPlayingAudio = false;
        }
    }
}
