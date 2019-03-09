using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{


    public TimerVariables timerVariables;
    public SunVariables sunVariables;

    //lights in the scene
    public Light sun, moon;
    public Canvas drawField;
    
    //the percentage of the cycle that is "daytime"
    private float dayTimeAmount;

    private float nightTimeAmount;
    private float turnToNight;
    private float daySeconds;
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
        daySeconds = timerVariables.dayLength - turnToNight;
        Debug.Log(daySeconds);
        StartCoroutine(MoveSun());
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

        Color morning = new Color(0.86f, 0.70f, 0.016f, 1);
        Color midDay = new Color(1, 1, 1, 1);
        Color Sunset = new Color(0.90f, 0.65f, 0.40f, 1);
        Color current = morning;

        //rewrite this to be based on a percentage of the total day elapsed.

        while (timer.daytime)
        {
            
            if (daySeconds > 0)
            {
                float timeSinceStartedLerping = Time.time - startedLerping;
                

                if (timeSinceStartedLerping <= (daySeconds / 2))
                {
                    
                    float percentageComplete = timeSinceStartedLerping / (daySeconds * 2) / Time.deltaTime / 3;
                    current = Color.Lerp(current, midDay, percentageComplete);
                    startedLerpingTwo = Time.time; 
                }
                else
                {
                    float timeSinceStartedLerpingTwo = Time.time - startedLerpingTwo;
                    float percentageComplete = timeSinceStartedLerpingTwo / (daySeconds * 2) / Time.deltaTime / 3;
                    current = Color.Lerp(current, Sunset, percentageComplete);
                }
                
                sun.color = current;
            }

            daySeconds -= Time.deltaTime;
            sun.gameObject.transform.Rotate(0, 0, speed * Time.deltaTime, Space.World);

            yield return null;
        }

    }

    
}
