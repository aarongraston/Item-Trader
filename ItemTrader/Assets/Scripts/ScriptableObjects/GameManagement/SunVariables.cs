using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Sun/Sun Variables")]
public class SunVariables : ScriptableObject
{
    [Range(10, 50)]public float startAngle;
    public float fadeTime;
    [Range(0, 1)]public float atmosphereEnd;
    public float sunIntensity;
    public float moonIntensity;
    public Color dayAmbient; 
    public Color nightAmbient;
}
