using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Timer/TimerVariables")]
public class TimerVariables : ScriptableObject
{
    public float gameDays;
    [Range(0, 900)]public float dayLength;
    [Range(0, 1)]public float dayTimeAmount;
    [Range(0, 1)]public float eventInterval;
}
