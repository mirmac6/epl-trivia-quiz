using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 10f;
    [SerializeField] float timeToShowCorrectAnswer = 5f;

    public bool loadNextQuestion = false;
    public bool isAnsweringQuestion = false;
    public float fillFraction;

    float timerValue;
    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if(isAnsweringQuestion)
        {
            if(timerValue > 0 )
            {
                fillFraction = timerValue / timeToCompleteQuestion;
            } else
            {
                timerValue = timeToShowCorrectAnswer;
                isAnsweringQuestion = false;
            }
        } else
        {
            if(timerValue > 0)
            {
                fillFraction = timerValue / timeToShowCorrectAnswer;
            } else
            {
                timerValue = timeToCompleteQuestion;
                isAnsweringQuestion = true;
                loadNextQuestion = true;
            }
        }
        
        Debug.Log(timerValue);
    }
}
