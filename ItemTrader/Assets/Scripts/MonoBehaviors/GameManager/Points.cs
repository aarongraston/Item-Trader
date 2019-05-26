using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{
    public GameObject pointDisplay;

    private TextMeshPro pointDisplayComponent;

    private RectTransform pointDisplayMover;

    private int pointsCollected = 0;
    private int[] digitsToDisplay;
    private string converter;
    private string displayString;
    private float floorHeight;

    private void Start()
    {
        pointDisplayComponent = pointDisplay.GetComponent<TextMeshPro>();
        pointDisplayMover = pointDisplay.GetComponent<RectTransform>();
        floorHeight = pointDisplayMover.anchoredPosition.y;
        digitsToDisplay = new int[9];
        for (int i = 0; i < digitsToDisplay.Length; i++) {
            digitsToDisplay[i] = 0;
        }
    }

    public void AddPoints(int i) {
        pointsCollected += i;
        DisplayPoints(pointsCollected);
    }

    private void DisplayPoints(int i) {
        displayString = "";
        converter = i.ToString();
        int numberOfZeros = digitsToDisplay.Length - converter.Length;
        for (int x = 0; x < numberOfZeros; x++) {
            displayString += "0";
        }
        for (int x = 0; x < converter.Length; x++) {
            displayString += converter[x];
        }
        pointDisplayComponent.text = displayString;
        StartCoroutine(PointsJump());
    }

    public int getPoints() {
        return int.Parse(displayString);
    }

    private IEnumerator PointsJump() {

        Vector3 velocity = Vector3.zero;
        float sleepThreshold = 0.7f;
        float bounceCooef = 0.4f;
        float gravity = -80f;

        velocity.y = 25f;

        while (velocity.magnitude > sleepThreshold || pointDisplayMover.anchoredPosition.y > floorHeight)
        {
            velocity.y += gravity * Time.fixedDeltaTime;

            pointDisplayMover.anchoredPosition += new Vector2(0, velocity.y * Time.fixedDeltaTime);
            if (pointDisplayMover.anchoredPosition.y <= floorHeight)
            {
                pointDisplayMover.anchoredPosition = new Vector2(pointDisplayMover.anchoredPosition.x, floorHeight);
                velocity.y = -velocity.y;
                velocity *= bounceCooef;
            }
            yield return null;
        }
    }


    
}
