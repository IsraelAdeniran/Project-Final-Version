using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthAmount = 30; // Amount of health to give
    public PlayerHealth playerHealth; // Reference to the PlayerHealth script

    void Update()
    {
        // Check if the mouse is over the pickup using Raycast
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                // Your logic to show UI tooltip or highlight the object goes here
                GiveHealthToPlayer();
            }
        }
    }

    void GiveHealthToPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Use the key you prefer for interaction
        {
            playerHealth.GainHealth(healthAmount);
            Destroy(gameObject); // Remove the health pickup
        }
    }

}
