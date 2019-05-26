using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public CoinVariables coinVars;
    private GameObject gameManager;

    private CoinManager coinManager;
    private Points pointManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        pointManager = gameManager.GetComponent<Points>();
        coinManager = gameManager.GetComponent<CoinManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Spin() {
        transform.Rotate(coinVars.spinSpeed, 0, 0);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player") {
            pointManager.AddPoints(coinVars.pointValue);
            coinManager.AddCoin();
            Destroy(gameObject);
        }
    }
}
