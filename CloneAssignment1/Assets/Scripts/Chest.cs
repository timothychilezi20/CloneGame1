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

    public bool activateShootAbility = false;

    public bool activateExplosionAbility = false; 

    private bool isOpened = false;

    public void Awake()
    {
        dashImage.SetActive(false);
        projectileImage.SetActive(false);  
        explosionImage.SetActive(false);
    }

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
                        AbilityUIManager.Instance.UnlockDash();
                    }
                }

                if (activateShootAbility)
                {
                   
                    PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
                    if (playerMovement != null)
                    {
                        playerMovement.canShoot = true;
                        AbilityUIManager.Instance.UnlockProjectile();
                    }
                }

                if (activateExplosionAbility)
                {
                   
                    PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
                    if (playerMovement != null)
                    {
                        playerMovement.canExplode = true;
                        AbilityUIManager.Instance.UnlockExplosion();
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
