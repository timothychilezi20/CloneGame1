using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterHouse : MonoBehaviour
{ 
    public GameObject enterHouseUI; 

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Trigger Entered"); 
            enterHouseUI.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enterHouseUI.SetActive(false);
        }
    }

    public void Enter()
    {
        SceneManager.LoadScene("Tshego Scene"); 
    }
}
