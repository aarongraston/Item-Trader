using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{
    float originalY;
    public float floatStrength = 0.0001f;
    public float speed = 3;
    public float heightMod = 0.25f;
    // Start is called before the first frame update
    void Start()
    {
        originalY = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<CharacterController>().Move(new Vector3(0, (Mathf.Sin(Time.time * speed) * floatStrength) * heightMod, 0)); 
    }
}
