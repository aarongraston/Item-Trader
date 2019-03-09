using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public delegate void TimerEventTrigger();
    public TimerEventTrigger timeEvent;

    public TimerVariables timerVariables;
    //the number of days in game
    public static float numDays;
    
    //one day from day to night is 15 minutes
    public static float dayLength;

    //holds the number of seconds of daylight
    public static float daylight;

    //holds the number of seconds of moonlight 
    public static float moonlight;

    //a boolean that holds whether it's day or night according to the facts
    public bool daytime;

    //the amount of time that passes before a daytime event is triggered
    public float dayEventInterval;

    //the amount of time that passes before a moontime event is triggered
    public float nightEventInterval;

    //private variables
    public float time;

    private void Start()
    {
        //set all the information

        numDays = timerVariables.gameDays;
        dayLength = timerVariables.dayLength;
        daylight = timerVariables.dayLength * timerVariables.dayTimeAmount;
        moonlight = timerVariables.dayLength - daylight;
        dayEventInterval = daylight * timerVariables.eventInterval;
        nightEventInterval = moonlight * timerVariables.eventInterval;

        daytime = true;
        time = dayLength;

        initGameTimer();
    }

    public void initGameTimer()
    {
        StartCoroutine(TimeTicker()); 
    }

    IEnumerator TimeTicker()
    {
        float dayIntervalCount = dayEventInterval;
        float nightIntervalCount = nightEventInterval;
        float changeToNight = dayLength - daylight;

        while (time > 0)
        {
           
            time -= Time.deltaTime;

            if (time <= changeToNight)
            {
                daytime = false;
                changeToNight = 0;
            }

            if (daytime)
            {
                dayIntervalCount -= Time.deltaTime;
                if (dayIntervalCount <= 0)
                {
                    float leftOverMil = dayIntervalCount;
                    timeEvent();
                    dayIntervalCount = dayEventInterval + leftOverMil;
                }
            }

            else
            {
                nightIntervalCount -= Time.deltaTime;
                if (nightIntervalCount <= 0)
                {
                    float leftOverMil = nightIntervalCount;
                    timeEvent();
                    nightIntervalCount = nightEventInterval + leftOverMil;
                }
            }

            if (time <= 0 && numDays > 0)
            {
                float leftOverMil = time;
                time = timerVariables.dayLength + time;
                numDays -= 1;
            }
            yield return null;

        }
       
    }

}


