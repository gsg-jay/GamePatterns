using UnityEngine;

public class ThirdPersonCamComponent : MonoBehaviour
{
    public Transform playerTransform;
    public float sensitivity = 2f;
    
    private float rotationX = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Rotate the camera based on mouse movement or right stick movement
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Apply rotation to the camera horizontally (around the player)
        playerTransform.Rotate(Vector3.up * mouseX);

        // Apply rotation to the camera vertically (up and down)
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); // Clamp vertical rotation to prevent flipping
        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
    }
}
