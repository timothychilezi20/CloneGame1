using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class closeGateTrigger : MonoBehaviour
{
    public GameObject closeGate;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    private Collider2D thisCollider;
    private bool runningTime;

    private void Start()
    {
        thisCollider = GetComponent<Collider2D>();
        thisCollider.enabled = true;
        runningTime = false;
    }

    void Update()
    {
        if (runningTime == true)
        {
            startTimer();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)//when entering the trigger
    {

        if (collision.CompareTag("Player"))
        {
            closeGate.SetActive(true);
            runningTime = true;
            Debug.Log("Timer Started");

            thisCollider.enabled=false;//at the end once the time starts
        }
 
    }

    public void startTimer()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)
        {
            remainingTime = 0;
        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
