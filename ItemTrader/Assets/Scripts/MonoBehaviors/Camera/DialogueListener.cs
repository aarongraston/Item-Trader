using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueListener : MonoBehaviour
{
    private bool playerIsTalking = false;
    private float originalSize;
    private Camera camComp;

    public CameraVariables camVars;

    private void Start()
    {
        camComp = gameObject.GetComponent<Camera>();
        originalSize = camComp.orthographicSize;       
    }

    public void Zoom(bool talk)
    {
        if (talk)
        {
            playerIsTalking = true;
            StartCoroutine(ZoomIn());
        }
        else
        {
            playerIsTalking = false;
            StartCoroutine(ZoomOut());
        }
    }

    public IEnumerator ZoomIn() {

        float startPoint;
        float time = 0.0f;

        if (camComp.orthographicSize < originalSize)
        {
            startPoint = camComp.orthographicSize;
        }
        else {
            startPoint = originalSize;
        }

        while (camComp.orthographicSize > (originalSize + camVars.zoomInAmount) && playerIsTalking == true) {

            time += Time.deltaTime * camVars.camMoveSpeed;
            camComp.orthographicSize = Mathf.Lerp(startPoint, originalSize + camVars.zoomInAmount, time);
            yield return null;
        }

        
    }

    public IEnumerator ZoomOut()
    {
        float startPoint;
        float time = 0.0f;

        if (camComp.orthographicSize > originalSize + camVars.zoomInAmount)
        {
            startPoint = camComp.orthographicSize;
        }
        else
        {
            startPoint = originalSize + camVars.zoomInAmount;
        }

        while (camComp.orthographicSize < (originalSize) && playerIsTalking == false)
        {
            time += Time.deltaTime * camVars.camMoveSpeed;
            camComp.orthographicSize = Mathf.Lerp(startPoint, originalSize , time);
            yield return null;
        }
    }

}
