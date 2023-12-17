using UnityEngine;

public class NPCController : MonoBehaviour
{
    private bool hasDamagedPlayer = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasDamagedPlayer && other.CompareTag("Player"))
        {
            hasDamagedPlayer = true;
            OnNPCDefeated();
        
        }
    }

    public void OnNPCDefeated()
    {
        // Assuming GameManagerX is accessible and has a method to update the score
        GameManagerX.instance.UpdateScore(10); // Increment score by 10 for each NPC defeated
    }
}
