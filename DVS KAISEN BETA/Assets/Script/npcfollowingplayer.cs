using UnityEngine;

public class NPCFollowingPlayer : MonoBehaviour
{
    public float speed = 3f;  // Adjust the speed of the NPC.
    public float minDistance = 1.5f;  // Minimum distance to maintain between NPC and player.

    private Transform player;  // Reference to the player's transform.

    void Start()
    {
        // Find the player using the tag "Player."
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (player == null)
        {
            Debug.LogError("Player not found! Make sure the player has the tag 'Player'.");
        }
    }

    void Update()
    {
        if (player != null)
        {
            // Calculate the direction from the NPC to the player.
            Vector3 direction = player.position - transform.position;

            // Check if the distance between NPC and player is greater than the minimum distance.
            if (direction.magnitude > minDistance)
            {
                // Normalize the direction vector to have a magnitude of 1.
                direction.Normalize();

                // Rotate the NPC towards the player using LookAt.
                transform.LookAt(player);

                // Move the NPC towards the player using MoveTowards for smoother movement.
                transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
        }
    }
}
