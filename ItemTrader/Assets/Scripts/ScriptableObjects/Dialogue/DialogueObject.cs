using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Dialogue/Dialogue Object")]
public class DialogueObject : ScriptableObject
{
    public string[] Dialogue;
    public ItemObject conditionalItem;
    public ItemObject itemToGive;
    
}
