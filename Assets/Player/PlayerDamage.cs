using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class PlayerDamage : MonoBehaviour
{
    private int sealHitsLeft = 2;

    public float knockBackForce = 15f;
    public float knockBackDuration = 0.3f;
    private Vector3 knockBackDirection;
    private float knockBackTimer;
    private bool isKnockedBack = false;

    private CharacterController controller;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isKnockedBack)
        {
            Debug.Log(knockBackDirection);
            Debug.Log(knockBackForce);
            controller.Move(knockBackDirection * knockBackForce * Time.deltaTime);
            Debug.Log("First: " + knockBackDirection * knockBackForce * Time.deltaTime);
            Debug.Log("Second: " + knockBackDirection * knockBackForce);
            knockBackTimer -= Time.deltaTime;
            if (knockBackTimer <= 0)
            {
                isKnockedBack = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Seal")
        {
            Debug.Log("Seal hit player");

            sealHitsLeft -= 1;
            if (sealHitsLeft == 1)
            {
                KnockBack(other);
            }
            else if (sealHitsLeft == 0)
            {
                GameManager.Instance.died = true;
                GameManager.Instance.diedToSeal = true;
                GameManager.Instance.EndingSequence();
            }
        }
    }

    private void KnockBack(Collider other)
    {
        Vector3 dir = transform.position - other.gameObject.transform.position;
        dir.y = 0;
        dir = dir.normalized;

        isKnockedBack = true;
        knockBackTimer = knockBackDuration;
        knockBackDirection = dir;
    }
}
