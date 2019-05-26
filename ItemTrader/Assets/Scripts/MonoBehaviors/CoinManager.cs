using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public GameObject coinDisplay;

    private TextMeshProUGUI coinDisplayComponent;

    private RectTransform coinDisplayMover;

    private int coinsCollected = 0;
    private int[] digitsToDisplay;
    private string converter;
    private string displayString;

    private float floorHeight;

    private void Start() {
        coinDisplayComponent = coinDisplay.GetComponent<TextMeshProUGUI>();
        coinDisplayMover = coinDisplay.GetComponent<RectTransform>();
        floorHeight = coinDisplayMover.anchoredPosition.y;
        digitsToDisplay = new int[4];
        for (int i = 0; i<digitsToDisplay.Length; i++) {
            digitsToDisplay[i] = 0;
        }
    }

    public void AddCoin()
    {
        
        coinsCollected += 1;
        DisplayCoins(coinsCollected);
    }

    private void DisplayCoins(int i)
    {
        displayString = "";
        converter = i.ToString();
        int numberOfZeros = digitsToDisplay.Length - converter.Length;
        for (int x = 0; x < numberOfZeros; x++)
        {
            displayString += "0";
        }
        for (int x = 0; x < converter.Length; x++)
        {
            displayString += converter[x];
        }
        coinDisplayComponent.text = displayString;
        StartCoroutine(CoinsJump());
    }

    private IEnumerator CoinsJump()
    {
        Vector3 velocity = Vector3.zero;
        float sleepThreshold = 0.5f;
        float bounceCooef = 0.4f;
        float gravity = -80f;

        velocity.y = 25f;

        while (velocity.magnitude > sleepThreshold || coinDisplayMover.anchoredPosition.y > floorHeight)
        {
            velocity.y += gravity * Time.fixedDeltaTime;

            coinDisplayMover.anchoredPosition += new Vector2(0, velocity.y * Time.fixedDeltaTime);
            if (coinDisplayMover.anchoredPosition.y <= floorHeight)
            {
                coinDisplayMover.anchoredPosition = new Vector2(coinDisplayMover.anchoredPosition.x, floorHeight);
                velocity.y = -velocity.y;
                velocity *= bounceCooef;
            }
            yield return null;
        }

        Debug.Log("made it out");
    }



}
