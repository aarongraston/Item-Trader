using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public Camera cam;
    public GameObject canvas;
    public GameObject textBoxContainer;

    private void FixedUpdate()
    {
        DisplayOverhead();
    }

    private void DisplayOverhead()
    {
        Vector2 viewPortPoint = cam.WorldToViewportPoint(transform.position);

        Vector2 WorldObject_ScreenPosition = new Vector2(
((viewPortPoint.x * canvas.GetComponent<RectTransform>().sizeDelta.x) - (canvas.GetComponent<RectTransform>().sizeDelta.x * 0.5f)),
((viewPortPoint.y * canvas.GetComponent<RectTransform>().sizeDelta.y) - (canvas.GetComponent<RectTransform>().sizeDelta.y * 0.5f)));

       ;

        textBoxContainer.GetComponent<RectTransform>().anchoredPosition = WorldObject_ScreenPosition;
    }
}
