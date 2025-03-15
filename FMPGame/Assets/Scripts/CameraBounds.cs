using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float smoothSpeed = 0.125f; // Smoothness of the camera movement
    public Vector3 offset; // Offset to keep the camera at a fixed position relative to the player

    public float minX, maxX, minY, maxY; // Boundaries for camera movement

    private Camera cam; // Reference to the Camera component

    void Start()
    {
        // Get the camera component
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        if (player != null)
        {
            // Calculate the desired position with the offset
            Vector3 desiredPosition = player.position + offset;

            // Clamp the position to keep the camera within bounds
            float cameraHalfHeight = cam.orthographicSize;
            float cameraHalfWidth = cameraHalfHeight * cam.aspect;

            desiredPosition.x = Mathf.Clamp(desiredPosition.x, minX + cameraHalfWidth, maxX - cameraHalfWidth);
            desiredPosition.y = Mathf.Clamp(desiredPosition.y, minY + cameraHalfHeight, maxY - cameraHalfHeight);

            // Smoothly transition to the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Apply the smoothed position to the camera
            transform.position = smoothedPosition;
        }
    }
}
