using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private int xpRequired = 50;
    [SerializeField] private GameObject chestOpenEffect;
    [SerializeField] private GameObject dashImage;
    [SerializeField] private GameObject projectileImage;
    [SerializeField] private GameObject explosionImage;
    public GameObject closedChest;

    public bool activateDashAbility = false;

    private bool isOpened = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isOpened) return;

        if (other.CompareTag("Player"))
        {
            if (XPManager.instance.TrySpendXP(xpRequired))
            {
                OpenChest();

                if (activateDashAbility)
                {
                    PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
                    if (playerMovement != null)
                    {
                        playerMovement.canDash = true;
                    }
                }
            }
            else
            {
                Debug.Log("Not enough XP to open this chest.");
            }
        }
    }

    void OpenChest()
    {
        isOpened = true;

        Debug.Log("Chest opened!");

        if (chestOpenEffect != null)
        {
            Instantiate(chestOpenEffect, transform.position, Quaternion.identity);
        }

        closedChest.SetActive(false);
    }
}
