using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatTrail : MonoBehaviour
{
    private float yPos;
    // Start is called before the first frame update
    void Start()
    {
        yPos = this.transform.position.y; 
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
    }
}
