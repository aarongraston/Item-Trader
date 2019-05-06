using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Scriptable Objects/Coin Variables")]
public class CoinVariables : ScriptableObject
{
    public float spinSpeed = 0.05f;
    public float size;
    public int pointValue = 10;
}
