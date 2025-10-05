using UnityEngine;
using UnityEngine.AI;
using System.Collections;

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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        m_Animator = GetComponent<Animator>();

        m_Agent.speed = defaultSpeed;
        currentLaunchCountdown = launchTimer;
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
            // m_Animator.SetBool("Attack", true);
        }
        else if (m_Distance < FollowDistance)
        {
            m_Agent.isStopped = false;
            // m_Animator.SetBool("Attack", false);

            currentLaunchCountdown -= Time.deltaTime;
            Debug.Log(currentLaunchCountdown);
            if (currentLaunchCountdown <= 0)
            {
                Debug.Log("launching");

                launching = true;
                m_Agent.isStopped = true;

                Vector3 dir = Target.position - transform.position;
                dir.y = 0;
                dir = dir.normalized;
                launchLocation = Target.position + dir * 10;

                StartCoroutine(Launch());
            }
            else
            {
                m_Agent.destination = Target.position;
            }
        }
        else
        {
            m_Agent.isStopped = false;
            // m_Animator.SetBool("Attack", false);
            m_Agent.destination = WaterHole.position;
        }
    }

    void OnAnimatorMove()
    {
        //if (m_Animator.GetBool("Attack") == false)
        //{
        //    m_Agent.speed = (m_Animator.deltaPosition / Time.deltaTime).magnitude;
        //}
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
