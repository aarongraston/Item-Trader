using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRight : MonoBehaviour
{

    public float moveAmount = 1;
    Vector3 move = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move = Vector3.zero;
        move = new Vector3(-moveAmount, 0, 0);
        this.transform.position += move;   
    }
}
