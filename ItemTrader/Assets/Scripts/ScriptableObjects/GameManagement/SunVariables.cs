﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Sun/Sun Variables")]
public class SunVariables : ScriptableObject
{
    [Range(10, 50)]public float startAngle;
}
