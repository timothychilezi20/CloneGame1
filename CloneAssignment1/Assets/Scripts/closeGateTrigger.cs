using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeGateTrigger : MonoBehaviour
{
    public GameObject closeGate;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered by: " + collision.gameObject.name);
        if (collision.CompareTag("Player"))
        {
            closeGate.SetActive(true);
        }
        this.gameObject.SetActive(false);//at the end once the time starts
    }
}
