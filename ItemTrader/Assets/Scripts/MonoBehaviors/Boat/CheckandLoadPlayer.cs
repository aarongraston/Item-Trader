using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckandLoadPlayer : MonoBehaviour
{
    private SphereCollider boatCollider;
    private GameObject player;
    private bool playerIsInTrigger = false;
    private Transform playerPos;

    private void Awake()
    {
        boatCollider = GetComponent<SphereCollider>();
        player = GameObject.FindWithTag("Player");
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == player.tag)
        {
            playerIsInTrigger = true; 
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == player.tag)
        {
            playerIsInTrigger = false;
        }
    }

    public void LoadPlayer()
    {
        if (playerIsInTrigger)
        {
            player.GetComponent<CharacterController>().enabled = false; 
            playerPos = transform.GetChild(0).transform;
            player.transform.position = playerPos.position;

        }

    }
}
