using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Player/Player Variables")]
public class PlayerVariables : ScriptableObject
{
    public float speed = 1f;
    public float turnSpeed = 0.25f;
    public float jumpSpeed = 20f;
    public float gravity = 9.8f;
    public float timeAirStall = 5f;
    public float movementInAirPercentage = 0.6f;

}
