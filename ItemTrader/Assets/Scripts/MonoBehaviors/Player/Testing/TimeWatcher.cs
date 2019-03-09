using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeWatcher : MonoBehaviour
{
    Timer time;
    public Material mat1;
    public Material mat2;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        time  = FindObjectOfType<Timer>();
        time.timeEvent += CheckInterval;
        rend.material = mat1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CheckInterval()
    {
        Debug.Log("checkInterval Called");

        if (rend.sharedMaterial == mat1)
        {
            rend.material = mat2;
        }
        else
        {
            rend.material = mat1; 
        }

    }
}
