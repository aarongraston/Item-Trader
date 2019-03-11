using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{


    public TimerVariables timerVariables;
    public SunVariables sunVariables;

    //lights in the scene
    public Light sun, moon, sunSet, sunRise;
    public Canvas drawField;
    
    //the percentage of the cycle that is "daytime"
    private float dayTimeAmount;

    private float nightTimeAmount;
    private float turnToNight;
    private float daySeconds;
    private float constDaySeconds;
    private float totalRotDistance;

    private Timer timer;

    //always turns to daytime at 0 seconds.

    private const float turnToDay = 0f;

    private void Start()
    {
        timer = FindObjectOfType<Timer>();

        sun.gameObject.transform.Rotate(0, 0, -sunVariables.startAngle, Space.World);
        totalRotDistance = sunVariables.startAngle * 2;

        dayTimeAmount = timerVariables.dayTimeAmount;
        nightTimeAmount = 1 - dayTimeAmount;
        turnToNight = nightTimeAmount * timerVariables.dayLength;
        daySeconds = timerVariables.dayLength * timerVariables.dayTimeAmount;
        constDaySeconds = daySeconds;
        StartCoroutine(MoveSun());
        sunSet.intensity = 0;
    }

    public void Update()
    {
        
    }

    IEnumerator MoveSun()
    {
        float startedLerping = Time.time;
        float startedLerpingTwo = 0f;
        float speed = totalRotDistance / daySeconds;
        float halfDay = daySeconds / 2;

        Color morning = new Color(0.91f, 0.75f, 0.39f, 1);
        Color midDay = new Color(0.91f, 0.86f, 0.80f, 1);
        Color Sunset = new Color(0.84f, 0.57f, 0.50f, 1);
        Color current = morning;

        //rewrite this to be based on a percentage of the total day elapsed.
        float timeSinceStartedLerping = Time.time - startedLerping;
        float timeSinceStartedLerpingTwo = 0f;
        float sunSetStart = 0f;

        while (timer.daytime)
        {
            
            if (daySeconds > 0)
            {

                if (timeSinceStartedLerping <= (constDaySeconds / 2))
                {
                    timeSinceStartedLerping += Time.deltaTime;
                    float percentageComplete = timeSinceStartedLerping / (constDaySeconds / 2);
                    current = Color.Lerp(morning, midDay, percentageComplete);
                    startedLerpingTwo = Time.time;

                    sunRise.intensity = Mathf.Lerp(1, 0, percentageComplete / sunVariables.atmosphereEnd);
                }
                else
                {
                    timeSinceStartedLerpingTwo += Time.deltaTime;
                    float percentageComplete = timeSinceStartedLerpingTwo / (constDaySeconds / 2);
                    current = Color.Lerp(midDay, Sunset, percentageComplete);

                    if (percentageComplete > (1 - sunVariables.atmosphereEnd))
                    {
                        sunSetStart += Time.deltaTime;
                        float divider = sunSetStart / (sunVariables.atmosphereEnd * (constDaySeconds / 2));
                        Debug.Log(divider);
                        sunSet.intensity = Mathf.Lerp(0, 1, divider);
                    }
                }
                
                sun.color = current;
            }

            daySeconds -= Time.deltaTime;
            sun.gameObject.transform.Rotate(0, 0, speed * Time.deltaTime, Space.World);

            yield return null;
        }

        StartCoroutine(MoveMoon());

    }

    IEnumerator MoveMoon()
    {
        while (!timer.daytime)
        {

            yield return null;
        }
    }

    IEnumerator FadeMoon()
    {
        if (moon.isActiveAndEnabled)
        {
            yield return null;
        }
    }
    IEnumerator FadeSun()
    {
        float fadeTime = sunVariables.fadeTime;
        
        if (sun.isActiveAndEnabled)
        {
            while (true)
            {
                yield return null;
            }
        }
    }

    
}
