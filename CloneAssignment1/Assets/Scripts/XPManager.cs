using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

public class XPManager : MonoBehaviour
{
    public int xpPoints;
    public TextMeshProUGUI xpText;

    public void Start()
    {
        UpdateXPText(); 
    }

    public void addXPPoints(int amount)
    {
        xpPoints += amount;
        UpdateXPText(); 
    }

    private void UpdateXPText()
    {
        xpText.text = "XP:" +xpPoints;
    }
}
