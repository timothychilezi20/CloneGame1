using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

public class XPManager : MonoBehaviour
{
    public static XPManager instance;
    public int xpPoints;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateUI();
    }

    public void addXPPoints(int amount)
    {
        xpPoints += amount;
        UpdateUI();
    }

    public bool TrySpendXP(int amount)
    {
        if (xpPoints >= amount)
        {
            xpPoints -= amount;
            UpdateUI();
            return true;
        }
        return false;
    }

    private void UpdateUI()
    {
        if (XPUIManager.Instance != null)
        {
            XPUIManager.Instance.UpdateXPText(xpPoints);
        }
        else
        {
            Debug.LogWarning("XPUIManager Instance not found.");
        }
    }
}
