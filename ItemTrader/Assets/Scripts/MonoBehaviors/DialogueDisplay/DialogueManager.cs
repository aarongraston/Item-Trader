using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public Camera cam;
    public GameObject canvas;
    public GameObject textBoxContainer;
    public DialogueDisplayVariables variables;
    public GameObject text;

    public void DisplayOverhead()
    {
        Vector2 viewPortPoint = cam.WorldToViewportPoint(transform.position);

        Vector2 WorldObject_ScreenPosition = new Vector2(
((viewPortPoint.x * canvas.GetComponent<RectTransform>().sizeDelta.x + variables.DialogueDisplayOffsetX) - ((canvas.GetComponent<RectTransform>().sizeDelta.x + variables.DialogueDisplayOffsetX) * 0.5f)),
((viewPortPoint.y * canvas.GetComponent<RectTransform>().sizeDelta.y + variables.DialogueDisplayOffsetY) - ((canvas.GetComponent<RectTransform>().sizeDelta.y + variables.DialogueDisplayOffsetY) * 0.5f)));

        textBoxContainer.GetComponent<RectTransform>().anchoredPosition = WorldObject_ScreenPosition;
    }

    public void UpdateText(string updateText)
    {
        text.GetComponent<TextMeshProUGUI>().text = updateText;
    }
}
