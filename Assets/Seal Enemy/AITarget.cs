using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using Unity.VisualScripting;

public class AITarget : MonoBehaviour
{
    public Transform Target;
    public Transform WaterHole;
    public float AttackDistance;
    public float FollowDistance;

    private NavMeshAgent m_Agent;
    private Animator m_Animator;
    private float m_Distance;

    [SerializeField] private float defaultSpeed;
    [SerializeField] private float defaultAcceleration;
    [SerializeField] private float launchTimer;
    private float currentLaunchCountdown;
    [SerializeField] private float launchSpeed;
    [SerializeField] private float launchAcceleration;
    private bool launching = false;
    private Vector3 launchLocation;

    private bool alreadyPlaying;
    
    public GameObject audioManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Agent = transform.parent.gameObject.GetComponent<NavMeshAgent>();
        m_Animator = GetComponent<Animator>();

        m_Agent.speed = defaultSpeed;
        currentLaunchCountdown = launchTimer;
        alreadyPlaying = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (launching)
            return;

        m_Distance = Vector3.Distance(m_Agent.transform.position, Target.position);
        if (m_Distance < AttackDistance)
        {
            m_Agent.isStopped = true;
            m_Animator.SetBool("Attack", true);
        }
        else if (m_Distance < FollowDistance)
        {
            m_Agent.isStopped = false;

            currentLaunchCountdown -= Time.deltaTime;
            Debug.Log(currentLaunchCountdown);

            GameManager.Instance.bgm.volume = 0.3f;
            // GameManager.Instance.sealAudio.volume = 1f;

            // GameManager.Instance.sealAudio.Play();
            
            
            // if (GameManager.Instance.calvinFuckingLosesIt)
            // {
            //     GameManager.Instance.bgm.clip = GameManager.Instance.sealButFromBrooklyn;
            //     // GameManager.Instance.bgm.PlayOneShot(GameManager.Instance.sealButFromBrooklyn, 0.3f);
            //     // alreadyPlaying = true;
            //
            // }
            // else if (GameManager.Instance.calvinFuckingLosesIt == false)
            // {
            //     GameManager.Instance.bgm.clip = GameManager.Instance.seal;
            //     // GameManager.Instance.bgm.PlayOneShot(GameManager.Instance.seal, 0.3f);
            //     // alreadyPlaying = true;
            // }
            
            // GameManager.Instance.bgm.volume = 0.5f;
            // GameManager.Instance.bgm.Play();
            
            if (currentLaunchCountdown <= 0)
            {
                Debug.Log("launching");

                launching = true;
                m_Animator.SetBool("Attack", true);
                m_Agent.isStopped = true;

                Vector3 dir = Target.position - transform.position;
                dir.y = 0;
                dir = dir.normalized;
                launchLocation = Target.position + dir * 10;


                
                StartCoroutine(Launch());
            }
            else
            {
                m_Animator.SetBool("Attack", false);
                m_Agent.destination = Target.position;


            }
        }
        else
        {
            m_Agent.isStopped = false;
            m_Animator.SetBool("Attack", false);
            m_Agent.destination = WaterHole.position;

            if (Vector3.Distance(m_Agent.transform.position, WaterHole.position) <= 2f)
            {
                m_Animator.SetBool("Attack", true);
            }
            
            //GameManager.Instance.bgm.clip = GameManager.Instance.mainMusic;
            //GameManager.Instance.bgm.volume = 0.75f;
            // alreadyPlaying = false;

        }
    }

    IEnumerator Launch()
    {
        Debug.Log("StartCoroutine");

        yield return new WaitForSeconds(2f);

        m_Agent.speed = launchSpeed;
        m_Agent.acceleration = launchAcceleration;
        m_Agent.destination = launchLocation;
        m_Agent.isStopped = false;

        Debug.Log("Launch");

        yield return new WaitForSeconds(1f);

        currentLaunchCountdown = launchTimer;
        m_Agent.speed = defaultSpeed;
        m_Agent.acceleration = defaultAcceleration;

        launching = false;

        Debug.Log("Reset");
    }
}
