using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public Camera cam;
    public GameObject textBoxContainer;

    private void FixedUpdate()
    {
        DisplayOverhead();
    }

    private void DisplayOverhead()
    {
        Vector3 viewPortPoint = cam.WorldToViewportPoint(transform.position);

        Debug.Log(viewPortPoint);
        Debug.Log(textBoxContainer.GetComponent<RectTransform>().anchoredPosition);

        textBoxContainer.GetComponent<RectTransform>().anchoredPosition = viewPortPoint;
    }
}
