using UnityEngine;

public class OutBound : MonoBehaviour
{
    public Transform floorTransform; // Reference to the floor's transform

    private float xRange;
    private float zRange;
    private float yMin;

    void Start()
    {
        // Make sure the floorTransform is assigned.
        if (floorTransform == null)
        {
          
            this.enabled = false; // Disable the script to prevent errors
            return;
        }

        // Calculate ranges based on floor's scale
        xRange = floorTransform.localScale.x / 2; // Assuming the floor's pivot is at the center
        zRange = floorTransform.localScale.z / 2; // Assuming the floor's pivot is at the center
        yMin = floorTransform.position.y; // This assumes you want to keep the object above the floor level
    }

    void Update()
    {
        // If floorTransform is not set, don't execute the rest of the code
        if (floorTransform == null)
            return;

        // Ensure the player stays within the x bounds of the floor
        float clampedX = Mathf.Clamp(transform.position.x, floorTransform.position.x - xRange, floorTransform.position.x + xRange);
        // Ensure the player stays within the z bounds of the floor
        float clampedZ = Mathf.Clamp(transform.position.z, floorTransform.position.z - zRange, floorTransform.position.z + zRange);
        // Ensure the player stays above the y level of the floor
        float clampedY = Mathf.Max(transform.position.y, yMin);

        // Set the player's position to the clamped values
        transform.position = new Vector3(clampedX, clampedY, clampedZ);
    }
}
