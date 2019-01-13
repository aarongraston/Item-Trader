using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Scriptable Objects/Camera/Camera Variables")]
public class CameraVariables : ScriptableObject
{
    public float percentScreenShift = 0.2f;
    public float camZoomAmount = 15f;
    public Vector3 camShiftAmount = new Vector3(17.8f, 0, 13f);
    public float camMoveSpeed = 3f;
}
