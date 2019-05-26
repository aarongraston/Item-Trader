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

    CharacterVariables charVars;

    public void Start()
    {
        charVars = gameObject.GetComponent<Character>().charVariables;
    }

    public void DisplayOverhead()
    {
        Vector2 viewPortPoint = cam.WorldToViewportPoint(transform.position);

        Vector2 WorldObject_ScreenPosition = new Vector2(
((viewPortPoint.x * canvas.GetComponent<RectTransform>().sizeDelta.x + variables.DialogueDisplayOffsetX + charVars.dialogueOffsetX) - ((canvas.GetComponent<RectTransform>().sizeDelta.x + variables.DialogueDisplayOffsetX + charVars.dialogueOffsetX) * 0.5f)),
((viewPortPoint.y * canvas.GetComponent<RectTransform>().sizeDelta.y + variables.DialogueDisplayOffsetY + charVars.dialogueOffsetY) - ((canvas.GetComponent<RectTransform>().sizeDelta.y + variables.DialogueDisplayOffsetY + charVars.dialogueOffsetY) * 0.5f)));

        textBoxContainer.GetComponent<RectTransform>().anchoredPosition = WorldObject_ScreenPosition;
    }

    public void DisableCanvas()
    {
        canvas.gameObject.SetActive(false);
    }

    public void EnableCanvas()
    {
        canvas.gameObject.SetActive(true);
    }

    public void UpdateText(string updateText)
    {
        text.GetComponent<TextMeshProUGUI>().text = updateText;
    }
}
