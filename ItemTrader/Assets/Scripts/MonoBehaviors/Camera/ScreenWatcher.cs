using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWatcher : MonoBehaviour
{
    //private variables
    private Camera theCam;
    private Vector3 Detector = Vector3.zero;
    private Transform playerTransform;
    private bool camMoving;
    private float screenWidth;
    private float screenHeight;

    //public variables
    public GameObject player;
    public float camMoveSpeed = 1f;

    // Start is called before the first frame update

    void Start()
    {
        theCam = gameObject.GetComponent<Camera>();
        camMoving = false;
        screenWidth = 17.8f;
        screenHeight = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        playerTransform = player.transform;
        Detector = theCam.WorldToViewportPoint(playerTransform.position);

        if (!camMoving)
        {
            if (Detector.x <= 0)
            {

                camMoving = true;
                StartCoroutine("moveLeft");
                return;
            }
        }



    }

    public IEnumerator moveLeft()
    {

        float amountLeft = screenWidth;

        while (amountLeft > 0)
        {
            amountLeft -= camMoveSpeed;
            this.transform.position += new Vector3(-camMoveSpeed, 0, 0);
            yield return null;
        }

        amountLeft = screenWidth;
        camMoving = false;


    }
}
