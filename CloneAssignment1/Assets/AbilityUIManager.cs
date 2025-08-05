using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityUIManager : MonoBehaviour
{
    public static AbilityUIManager Instance;

    public GameObject dashImage;
    public GameObject projectileImage;
    public GameObject explosionImage;

    public bool hasDash;
    public bool hasProjectile;
    public bool hasExplosion;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        dashImage.SetActive(false);
        projectileImage.SetActive(false);
        explosionImage.SetActive(false);
    }

    public void UnlockDash()
    {
        hasDash = true;
        StartCoroutine(ShowAbilityImage(dashImage));
    }

    public void UnlockProjectile()
    {
        hasProjectile = true;
        StartCoroutine(ShowAbilityImage(projectileImage));
    }

    public void UnlockExplosion()
    {
        hasExplosion = true;
        StartCoroutine(ShowAbilityImage(explosionImage));
    }

    private IEnumerator ShowAbilityImage(GameObject abilityImage)
    {
        abilityImage.SetActive(true);
        yield return new WaitForSeconds(10f);
        abilityImage.SetActive(false);
    }
}