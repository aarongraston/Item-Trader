using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Items/Item Object")]
public class ItemObject : ScriptableObject
{
    public string itemName;
    public GameObject item; 
}
