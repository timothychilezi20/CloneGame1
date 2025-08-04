using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class XPUIManager : MonoBehaviour
{
    public static XPUIManager Instance;
    public TextMeshProUGUI xpText;

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
        }
    }

    public void UpdateXPText(int xp)
    {
        if (xpText != null)
        {
            xpText.text = "XP: " + xp;
        }
            
    }
}
