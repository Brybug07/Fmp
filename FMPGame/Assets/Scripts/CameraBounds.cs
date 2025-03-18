/*using UnityEngine;
using Unity.Cinemachine;

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
*/

using UnityEngine;
using Unity.Cinemachine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float smoothSpeed = 0.125f; // Smoothness of the camera movement
    public Vector3 offset; // Offset to keep the camera at a fixed position relative to the player

    public float minX, maxX, minY, maxY; // Boundaries for camera movement

    private CinemachineCamera virtualCamera; // Reference to the CinemachineVirtualCamera
    private Camera cam; // Reference to the Camera component controlled by Cinemachine

    void Start()
    {
        // Get the CinemachineVirtualCamera component
        virtualCamera = GetComponent<CinemachineCamera>();

        // Get the Camera component controlled by Cinemachine
        cam = virtualCamera.GetComponentInChildren<Camera>();

        // Ensure the virtual camera follows the player
        if (virtualCamera != null)
        {
            virtualCamera.Follow = player;
        }
    }

    void LateUpdate()
    {
        if (player != null)
        {
            // Calculate the desired position with the offset
            Vector3 desiredPosition = player.position + offset;

            // Get the camera's aspect and orthographic size for boundary calculation
            if (cam != null)
            {
                float cameraHalfHeight = cam.orthographicSize;
                float cameraHalfWidth = cameraHalfHeight * cam.aspect;

                // Clamp the position to keep the camera within the bounds
                float clampedX = Mathf.Clamp(desiredPosition.x, minX + cameraHalfWidth, maxX - cameraHalfWidth);
                float clampedY = Mathf.Clamp(desiredPosition.y, minY + cameraHalfHeight, maxY - cameraHalfHeight);

                // If the camera is already at a boundary, stop further movement
                if (desiredPosition.x == clampedX && desiredPosition.y == clampedY)
                {
                    // Stop moving in this direction
                    desiredPosition.x = clampedX;
                    desiredPosition.y = clampedY;
                }
                else
                {
                    // If within bounds, apply the smooth movement
                    desiredPosition.x = Mathf.Lerp(transform.position.x, clampedX, smoothSpeed);
                    desiredPosition.y = Mathf.Lerp(transform.position.y, clampedY, smoothSpeed);
                }
            }

            // Smoothly transition to the desired position using Lerp
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Apply the smoothed position to the camera
            transform.position = smoothedPosition;
        }
    }
}
