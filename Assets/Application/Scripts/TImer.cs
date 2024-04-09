using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TImer : MonoBehaviour
{
    public float timeRemaining = 10;
    [SerializeField] bool timerIsRunning;
    [SerializeField] TMP_Text timeText;
    [SerializeField] private Animator _timer_animator;

    private void Start()
    {
        timerIsRunning = true;
    }

    void Update()
    {
        TimeRunning();
        Warning();
    }

    void TimeRunning()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    void Warning()
    {
        if (timerIsRunning)
        {
            if (timeRemaining < 3)
            {
                timeText.color = Color.red;
            }
            else
            {
                timeText.color = Color.black;
                return;
            }
        }
    }
    
    
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
