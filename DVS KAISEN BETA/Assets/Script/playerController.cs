using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour
{
    public GameObject projectilePrefab; // Reference to the projectile prefab
    public Transform shootingPoint; // Point where the projectile is spawned
    public AudioClip shootingSound; // Add this to reference the shooting sound
    public PlayerHealth playerHealth; // Add this to reference the PlayerHealth script

    private float speed = 15.0f;
    private float turnSpeed = 150.0f;
    private float horizontalInput;
    private float forwardInput;
    private Animator animator;
    private bool canShoot = true;
    private AudioSource audioSource;

    // Add the health pack properties here
    public int healthPackAmount = 20; // The amount of health a health pack will restore

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

        bool isWalking = forwardInput > 0;
        bool isWalkingBackward = forwardInput < 0;

        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            animator.SetTrigger("ShootTrigger");
            Shoot();
        }

        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isWalkingBackward", isWalkingBackward);
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, shootingPoint.position, shootingPoint.rotation);
        Destroy destroyScript = projectile.GetComponent<Destroy>();
        if (destroyScript != null)
        {
            destroyScript.DestroyObject(0.3f);
        }
        PlayShootingSound();
        StartCoroutine(ShootingCooldown());
    }

    void PlayShootingSound()
    {
        if (shootingSound != null)
        {
            audioSource.PlayOneShot(shootingSound);
        }
    }

    IEnumerator ShootingCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(1f);
        canShoot = true;
    }

    // OnTriggerEnter method to detect collision with a health pack
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HealthPack")) // Make sure your health pack has the "HealthPack" tag
        {
            GainHealth(healthPackAmount);
            Destroy(other.gameObject); // Destroy the health pack object
        }
    }
    public void GainHealth(int amount)
    {
        if (playerHealth != null)
        {
            playerHealth.GainHealth(amount); // Call the GainHealth method from the PlayerHealth script
        }
    }

    // Add these methods to handle animation events
    public void FootR()
    {
        // Code to execute when the right foot animation event is triggered
    }

    public void FootL()
    {
        // Code to execute when the left foot animation event is triggered
    }

    public void Hit()
    {
        // Code to execute when the hit animation event is triggered
    }
}
