using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    //lights in the scene
    public Light sun, moon;

    

    //the amount of the 15 minute day that is "daytime"
    [Range(0, 1)]public float dayTimeAmount = 0.5f;

    //one day from day to night is 15 minutes
    private const float fullDayTime = 900f;

    private float nightTimeAmount;
    private float turnToNight;

    //always turns to daytime at 0 seconds.

    private const float turnToDay = 0f;

    private void Start()
    {
        nightTimeAmount = 1 - dayTimeAmount;
        turnToNight = dayTimeAmount * fullDayTime;
    }

    public void Update()
    {

    }
}
