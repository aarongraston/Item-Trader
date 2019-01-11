using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "My Assets/Item")]
public class Item : ScriptableObject
{
    public Sprite sprite;
    public GameObject itemObject;
}
