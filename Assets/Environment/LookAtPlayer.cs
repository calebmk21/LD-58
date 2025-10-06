using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public bool inTent = false;
    
    
    
    [SerializeField] Transform player;

    private Vector3 Cameraoffset;

    private Vector3 tentCameraPos = new Vector3(138.1f, 8.2f, 90.5f);
    private Vector3 tentCameraRot = new Vector3(-14.7f, -100.2f, 3f);
    
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
        if (!inTent)
        {
            HandleCameraRotation();
            transform.position = player.position + Cameraoffset;
        }
        else
        {
            transform.position = tentCameraPos;
            transform.rotation = Quaternion.Euler(tentCameraRot);
        }
    }

    void HandleCameraRotation()
    {
        rotY += inputHandler.looking.x * lookSpeed * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(0, rotY, 0);
    }
}
