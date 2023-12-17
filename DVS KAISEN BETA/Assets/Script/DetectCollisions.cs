using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    public float damage = 50f; // The amount of damage dealt to the boss

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("npc"))
        {
            // Destroy only NPCs
            Destroy(other.gameObject);
        }
    }
}
