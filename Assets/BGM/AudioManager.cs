using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip defaultAmbience;

    private AudioSource track01, track02, track03;

    private bool isPlayingTrack01;
    private bool isPlayingTrack02;
    private bool isPlayingTrack03;


    public static AudioManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    private void Start()
    {
        track01 = gameObject.AddComponent<AudioSource>();
        track02 = gameObject.AddComponent<AudioSource>();
        track03 = gameObject.AddComponent<AudioSource>();
        isPlayingTrack01 = true;

        SwapTrack(defaultAmbience);
    }
    public void SwapTrack(AudioClip newClip)
    {
        if (isPlayingTrack01)
        {
            track02.clip = newClip;
            track02.Play();
            track01.Stop();
        }
        else
        {
            track01.clip = newClip;
            track01.Play();
            track02.Stop();

        }
    }
}
