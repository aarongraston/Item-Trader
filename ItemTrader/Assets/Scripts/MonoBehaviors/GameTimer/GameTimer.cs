using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private float constNightSeconds;
    private float totalRotDistance;

    private Vector3 sunStartRotation;
    private Vector3 moonStartRotation;

    private Timer timer;

    //always turns to daytime at 0 seconds.

    private const float turnToDay = 0f;

    private void Start()
    {
        timer = FindObjectOfType<Timer>();

        sunStartRotation = sun.transform.eulerAngles;
        moonStartRotation = moon.transform.eulerAngles;

        sun.gameObject.transform.Rotate(0, 0, -sunVariables.startAngle, Space.World);
        sun.intensity = sunVariables.sunIntensity;
        RenderSettings.ambientLight = sunVariables.dayAmbient;
        totalRotDistance = sunVariables.startAngle * 2;

        dayTimeAmount = timerVariables.dayTimeAmount;
        nightTimeAmount = 1 - dayTimeAmount;
        turnToNight = nightTimeAmount * timerVariables.dayLength;
        daySeconds = timerVariables.dayLength * timerVariables.dayTimeAmount;
        constNightSeconds = turnToNight;
        constDaySeconds = daySeconds;
        StartCoroutine(MoveSun());
        sunSet.intensity = 0;

        StartCoroutine(MoveSunUI());
    }

    public void Update()
    {
        
    }

    IEnumerator MoveSun()
    {
        sun.transform.eulerAngles = sunStartRotation;
        sun.gameObject.transform.Rotate(0, 0, -sunVariables.startAngle, Space.World);

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
                        sunSet.intensity = Mathf.Lerp(0, 1, divider);
                    }
                }
                
                sun.color = current;
            }

            daySeconds -= Time.deltaTime;
            sun.gameObject.transform.Rotate(0, 0, speed * Time.deltaTime, Space.World);
            moon.gameObject.transform.Rotate(0, 0, speed * Time.deltaTime, Space.World);

            yield return null;
        }

        daySeconds = constDaySeconds;

        StartCoroutine(FadeMoon());
        StartCoroutine(FadeSun());
        StartCoroutine(MoveMoon());

    }

    IEnumerator MoveMoon()
    {
        moon.transform.eulerAngles = moonStartRotation;
        moon.gameObject.transform.Rotate(0, 0, -sunVariables.startAngle, Space.World);

        float counter = 0f;
        float speed = totalRotDistance / turnToNight;

        while (!timer.daytime)
        {
            if (turnToNight > 0)
            {
                turnToNight -= Time.deltaTime;
                moon.gameObject.transform.Rotate(0, 0, speed * Time.deltaTime, Space.World);
                sun.gameObject.transform.Rotate(0, 0, speed * Time.deltaTime, Space.World);
            }
            yield return null;
        }

        turnToNight = constNightSeconds;

        StartCoroutine(FadeMoon());
        StartCoroutine(FadeSun());
        StartCoroutine(MoveSun());
    }

    IEnumerator FadeMoon()
    {

        float fadeTime = sunVariables.fadeTime;

        if (moon.isActiveAndEnabled)
        {
            float intensity = moon.intensity;
            float countUp = 0f;

            while (countUp < fadeTime)
            {
                moon.intensity = Mathf.Lerp(intensity, 0, countUp / fadeTime);
                RenderSettings.ambientLight = Color.Lerp(sunVariables.nightAmbient, sunVariables.dayAmbient, countUp / fadeTime);
                countUp += Time.deltaTime;
                yield return null;
            }
            moon.gameObject.SetActive(false);
        }
        else
        {
            moon.gameObject.SetActive(true);
            float countUp = 0f;

            while (countUp < fadeTime)
            {
                moon.intensity = Mathf.Lerp(0, sunVariables.moonIntensity, countUp / fadeTime);
                sunSet.intensity = Mathf.Lerp(1, 0, countUp / fadeTime);
                RenderSettings.ambientLight = Color.Lerp(sunVariables.dayAmbient, sunVariables.nightAmbient, countUp / fadeTime); 
                countUp += Time.deltaTime;
                yield return null;
            }
        }
    }

    IEnumerator FadeSun()
    {
        float fadeTime = sunVariables.fadeTime;

        if (sun.isActiveAndEnabled)
        {
            float intensity = sun.intensity;
            float countUp = 0f;

            while (countUp < fadeTime)
            {
                sun.intensity = Mathf.Lerp(intensity, 0, countUp / fadeTime);
                countUp += Time.deltaTime;
                yield return null;
            }
            sun.gameObject.SetActive(false);
        }
        else
        {
            sun.gameObject.SetActive(true);
            float countUp = 0f;

            while (countUp < fadeTime)
            {
                sun.intensity = Mathf.Lerp(0, sunVariables.sunIntensity, countUp / fadeTime);
                sunRise.intensity = Mathf.Lerp(0, 1, countUp / fadeTime);
                countUp += Time.deltaTime;
                yield return null;
            }
            
        }
    }

    IEnumerator MoveSunUI()
    {
        yield return new WaitForEndOfFrame();
        RectTransform[] images;
        Transform imageHolder = drawField.gameObject.transform.Find("TimeLine");
        RectTransform sun = drawField.gameObject.transform.Find("MoonSun").GetComponent<RectTransform>();


        images = imageHolder.GetComponentsInChildren<RectTransform>();
        Debug.Log("total distance to move: " + images[images.Length - 1].anchoredPosition.x);
        float distance = images[images.Length - 1].anchoredPosition.x;

        float speedNight = distance / constNightSeconds;
        float countUp = 0f;

        while (timer.daytime)
        {
            countUp += Time.deltaTime;
            Debug.Log(countUp);
            Debug.Log(Mathf.Lerp(0, distance, countUp / constDaySeconds));
            sun.anchoredPosition = new Vector2(Mathf.Lerp(-(distance / 2), (distance / 2), countUp / constDaySeconds), sun.anchoredPosition.y);
            yield return null;
        }





        }

    
}
