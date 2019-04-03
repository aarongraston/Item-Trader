using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool checkHeld(PlayerStateController pc) {
        if (pc.item == gameObject)
        {
            return true;
        }
        else
            return false;
    }

    public void setItem(PlayerStateController pc) {
        if (pc.item == gameObject) {
            rb.isKinematic = false;
            rb.useGravity = true;
        }

        if (pc.item != gameObject) {
            
        }
    }
}
