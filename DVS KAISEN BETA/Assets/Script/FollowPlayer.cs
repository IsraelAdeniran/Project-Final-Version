using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform playerTransform; // Reference to the player's transform
    public float rotationSpeed = 5f; // Adjust as needed
    public float distance = 5f; // Distance from the player in the horizontal plane
    public float height = 2f; // Height above the player

    void Start()
    {
        // Check if a player transform is not assigned
        if (playerTransform == null)
        {
          
        }
    }

    void Update()
    {
        // Check if a player transform is assigned
        if (playerTransform != null)
        {
            // Calculate the desired position based on the player's position and fixed offset
            Vector3 offset = new Vector3(0f, height, -distance);
            Vector3 desiredPosition = playerTransform.TransformPoint(offset);

            // Smoothly interpolate to the desired position
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * rotationSpeed);

            // Make the camera look at the player's position
            transform.LookAt(playerTransform);
        }
    }
}
