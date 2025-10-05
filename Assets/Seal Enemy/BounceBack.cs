using UnityEngine;

public class BounceBack : MonoBehaviour
{
    [SerializeField] float bounceForce;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        if (collision.transform.tag == "Player")
        {
            Debug.Log("Collision with player");
            Rigidbody otherRB = collision.rigidbody;
            otherRB.AddExplosionForce(bounceForce, collision.contacts[0].point, 5);
            Debug.Log("Bounce back");
        }
    }
}
