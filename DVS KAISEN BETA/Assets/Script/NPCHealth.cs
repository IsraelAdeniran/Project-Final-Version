using UnityEngine;

public class NPCHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected!");

        // Check if the collided object has the Player tag
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player detected!");
            TakeDamage(10); // or any other damage value you want
        }
    }


    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("NPC Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Implement death behavior here (e.g., play death animation, disable NPC, etc.).
        Destroy(gameObject);
    }

}
