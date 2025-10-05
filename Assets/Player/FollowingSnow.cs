using UnityEngine;

public class FollowingSnow : MonoBehaviour
{
    [SerializeField] Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = player.position;
        newPosition.y += 14f;
        transform.position = newPosition;
    }
}
