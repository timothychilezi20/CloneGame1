using System.Collections;
using System.Collections.Generic;
using System.Timers;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class closeGateTrigger : MonoBehaviour
{
    public GameObject closeGate;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    private Collider2D thisCollider;
    private bool runningTime;
    private float elapsedTime;
    private int timerCounter;
    [SerializeField] float endBreakTime;
    [SerializeField] float secondRemainingTime;
    [SerializeField] bool secondRound = false;

    private void Start()
    {
        thisCollider = GetComponent<Collider2D>();
        thisCollider.enabled = true;
        runningTime = false;
        secondRound = false;
    }

    void Update()
    {
        if (runningTime == true)
        {
            countdownTimer();
            //secondRound = true;
            //runningTime = false;
        }

        if (remainingTime == 0)
        {
            runningTime = false;
            elapsedTime += Time.deltaTime;
            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            if (elapsedTime >= endBreakTime && runningTime == false)
            {
                secondRound = true;
                runningTime = true;
                remainingTime = secondRemainingTime;
                timerCounter++;
                
            }
            if (secondRound == true && timerCounter>1)
            {
                runningTime = false;
                timerText.text = string.Format("{0:00}:{1:00}", 0, 0);
                //remainingTime = 0;
                closeGate.SetActive(false);
            }
            //if (secondRound == true)
            //{
            //}

            //countdownTimer();
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

    public void countdownTimer()
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

    public void breaktimer()
    {
        //if (remainingTime > 0)
        //{

        //}
        //else if (remainingTime < 0)
        //{
        //    remainingTime = 0;
        //}
        //elapsedTime += Time.deltaTime;
        //int minutes = Mathf.FloorToInt(elapsedTime / 60);
        //int seconds = Mathf.FloorToInt(elapsedTime % 60);
        //timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        //if (elapsedTime >= endBreakTime)
        //{
        //    elapsedTime = remainingTime;
        //}
    }
}
