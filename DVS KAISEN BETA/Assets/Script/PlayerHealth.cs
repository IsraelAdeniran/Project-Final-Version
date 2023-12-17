using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float Health, MaxHealth; // Make sure these are set in the inspector or initialized before use.

    [SerializeField]
    private HealthBarUI healthBar; // This should be linked in the inspector.

    void Start()
    {
        Health = MaxHealth; // Initialize Health to MaxHealth at start.
        healthBar.SetMaxHealth(MaxHealth);
    }

    void Update()
    {
        // Your other update logic here
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("npc"))
        {
            TakeDamage(10f); // Use the TakeDamage function to handle health changes.
        }
    }

    public void TakeDamage(float damageAmount)
    {
        Health -= damageAmount;
        Health = Mathf.Clamp(Health, 0, MaxHealth); // Ensure Health doesn't go below 0
        healthBar.SetHealth(Health);

        if (Health <= 0)
        {
            GameManagerX.instance.GameOver(); // Call GameOver when health is depleted
        }
    }
    public void IncreaseMaxHealth(float amount)
    {
        MaxHealth += amount;
        Health = MaxHealth; // Optionally, you can also fill up the health to MaxHealth
        healthBar.SetMaxHealth(MaxHealth);
        healthBar.SetHealth(Health);
    }

    // Add a method for health regeneration
    public IEnumerator RegenerateHealth(float amount, float duration)
    {
        float end = Time.time + duration;
        while (Time.time < end)
        {
            Health += amount;
            Health = Mathf.Clamp(Health, 0, MaxHealth);
            healthBar.SetHealth(Health);
            yield return new WaitForSeconds(1f); // Wait for 1 second between each regen tick
        }
    }

    // Method to increase health when picking up a health pack
    public void GainHealth(int amount)
    {
        Health += amount;
        Health = Mathf.Clamp(Health, 0, MaxHealth);
        healthBar.SetHealth(Health);
    }

}