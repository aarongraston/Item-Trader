﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Scriptable Objects/Camera/Camera Variables")]
public class CameraVariables : ScriptableObject
{
    public float percentScreenShift = 0.2f;
    public float camZoomAmount = 15f;
    public Vector3 camShiftAmount = new Vector3(17.8f, 0, 13f);
    public float smoothTime = 0.05f;


    public float camMoveSpeed = 0.25f;
    public float zoomInAmount = 5f;
}
