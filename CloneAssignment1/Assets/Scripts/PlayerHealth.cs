using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 3;
    public int currentLives;

    // Prefab for the heart icon (assign via the Inspector)
    public GameObject lifeIconPrefab;
    // The UI Panel (with Horizontal Layout Group) that will contain heart icons
    public Transform lifePanel;

    
    private List<GameObject> lifeIcons = new List<GameObject>();

    private void Start()
    {
        currentLives = maxLives;
        SetupLivesUI();
    }

    // Rebuild the lives UI
    private void SetupLivesUI()
    {
        // Clear existing icons (if any)
        foreach (Transform child in lifePanel)
        {
            Destroy(child.gameObject);
        }
        lifeIcons.Clear();

        // Create icons for the current lives
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
        // Update the UI icons to reflect new life count
        SetupLivesUI();

        if (currentLives <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player Died!");
        
        Destroy(gameObject);
    }
}