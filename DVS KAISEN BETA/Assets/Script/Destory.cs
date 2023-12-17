using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Call this method to destroy the GameObject after a delay
    public void DestroyObject(float delay)
    {
        // Invoke the DestroyDelayed method after the specified delay
        Invoke("DestroyDelayed", delay);
    }

    // Destroy the GameObject
    private void DestroyDelayed()
    {
        Destroy(gameObject);
    }
}
