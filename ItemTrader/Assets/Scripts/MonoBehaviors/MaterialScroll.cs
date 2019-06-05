using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialScroll : MonoBehaviour
{

    public float verticalScrollSpeed = 0.25f;
    private Renderer theMat;

    private bool scroll = true;
    
    // Start is called before the first frame update
    void Start()
    {
        theMat = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (scroll) {
            float verticalOffset = Time.time * verticalScrollSpeed;
            theMat.material.mainTextureOffset = new Vector2(0, verticalOffset);
        }
    }
}
