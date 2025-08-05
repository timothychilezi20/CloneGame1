using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 3;
    public int currentLives;

    public GameObject lifeIconPrefab;
    public Transform lifePanel;

    private List<GameObject> lifeIcons = new List<GameObject>();

    private SpriteFlashEffect flashEffect; // NEW

    public GameObject gameOverCanvas;

    private void Start()
    {
        currentLives = Mathf.Clamp(currentLives, 0, maxLives); // Add this to clamp lives

        if (currentLives == 0)
            currentLives = maxLives; // If unset, start at full

        SetupLivesUI();
        flashEffect = GetComponent<SpriteFlashEffect>();
    }

    public void SetupLivesUI()
    {
        foreach (Transform child in lifePanel)
        {
            Destroy(child.gameObject);
        }
        lifeIcons.Clear();

        for (int i = 0; i < currentLives; i++)
        {
            GameObject icon = Instantiate(lifeIconPrefab, lifePanel);
            lifeIcons.Add(icon);
        }
    }

    public void TakeDamage(int amount)
    {
        currentLives -= amount;
        if (currentLives < 0)
            currentLives = 0;

        Debug.Log("Player hit! Lives left: " + currentLives);
        SetupLivesUI();

        if (flashEffect != null) // NEW
        {
            flashEffect.Flash(); // 🔥 This makes the player flash!
        }

        if (currentLives <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player Died!");
        Destroy(gameObject);
        gameOverCanvas.SetActive(true);
    }
}
