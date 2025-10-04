using UnityEngine;
using UnityEngine.AI;

public class PlayerDamage : MonoBehaviour
{
    private int sealHitsLeft = 2;
    private bool fellInWater = false;

    public float knockBackForce = 5f;
    public float knockBackDuration = 5f;
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
                // Player dies
            }
        }
        else if (other.gameObject.tag == "Water")
        {
            // Player dies
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
