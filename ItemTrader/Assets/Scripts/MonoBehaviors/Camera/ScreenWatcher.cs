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

    //Camera settings:
    //holds 3 different variables for zoom amount, shift amount, and percent of screen travelled before shift.

    [SerializeField]
    private CameraVariables camVariables;

    //public variables
    public GameObject player;

    // Start is called before the first frame update

    void Start()
    {
        theCam = gameObject.GetComponent<Camera>();
        theCam.orthographicSize = camVariables.camZoomAmount;
        camMoving = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerTransform = player.transform;
        
        //a two dimensional vector for tracking the percentage of the player's positon across the screen width and height
        Detector = theCam.WorldToViewportPoint(playerTransform.position);
        
        if (!camMoving)
        {
            //the detector is going detect when a player is a percentage of the screenspace close to leaving an edge of the screen, and shift the camera to the next panel.
            
            //move the camera left
            if (Detector.x <= camVariables.percentScreenShift)
            {
                //set the flag for camera movement so it finishes moving before potentially being called to move again.
                camMoving = true;
                StartCoroutine(move(camVariables.camShiftAmount.x, new Vector3(-camVariables.camMoveSpeed, 0, 0)));
                return;
            }

            //move the camera right
            if (Detector.x >= (1 - camVariables.percentScreenShift))
            {
                camMoving = true;
                StartCoroutine(move(camVariables.camShiftAmount.x, new Vector3(camVariables.camMoveSpeed, 0, 0)));
                return;
            }

            //move the camera down
            if (Detector.y <= camVariables.percentScreenShift)
            {
                camMoving = true;
                StartCoroutine(move(camVariables.camShiftAmount.z, new Vector3(0, 0, -camVariables.camMoveSpeed)));
                return;
            }

            //move camera up
            if (Detector.y >= (1 - camVariables.percentScreenShift))
            {
                camMoving = true;
                StartCoroutine(move(camVariables.camShiftAmount.z, new Vector3(0, 0, camVariables.camMoveSpeed)));
                return;
            }
        }



    }

    public IEnumerator move(float shiftAmount, Vector3 moveMent)
    {
        float amountLeft = shiftAmount;

        while (amountLeft > 0)
        {
            amountLeft -= camVariables.camMoveSpeed;
            this.transform.Translate(moveMent, Space.World);
            yield return null;
        }

        camMoving = false;
        
    }

}
