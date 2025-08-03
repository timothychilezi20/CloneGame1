using UnityEngine;

public class LifeGemPickup : MonoBehaviour
{
    public int lifeValue = 1;
    public AudioClip pickupSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();

            if (playerHealth != null && playerHealth.currentLives < playerHealth.maxLives)
            {
                playerHealth.currentLives += lifeValue;
                playerHealth.SetupLivesUI();
                Debug.Log("💖 Life gem collected! Lives: " + playerHealth.currentLives);
            }

            if (pickupSound != null)
            {
                AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            }

            Destroy(gameObject); // Remove gem
        }
    }
}
