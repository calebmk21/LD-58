using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField] Transform player;

    private Vector3 Cameraoffset;

    public float lookSpeed = 7f;

    [SerializeField] InputHandler inputHandler;
    private float rotY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cameraoffset = transform.position - player.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        HandleCameraRotation();
        transform.position = player.position + Cameraoffset;
    }

    void HandleCameraRotation()
    {
        rotY += inputHandler.looking.x * lookSpeed * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(0, rotY, 0);
    }
}
