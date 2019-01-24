using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckandLoadPlayer : MonoBehaviour
{
    private SphereCollider boatCollider;
    private GameObject player;
    private bool playerIsInTrigger = false;
    private Transform playerPos;

    public BoatState idleState;
    public BoatState activeState;

    private void Awake()
    {
        boatCollider = GetComponent<SphereCollider>();
        player = GameObject.FindWithTag("Player");
        gameObject.GetComponent<BoatStateController>().ChangeState(idleState);
        
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
            
            //set the player to the proper position
            player.GetComponent<CharacterController>().enabled = false; 
            playerPos = transform.GetChild(0).transform;
            player.transform.position = playerPos.position;

            //

            GetComponent<BoatStateController>().ChangeState(activeState);
        }

    }

    public void UnloadPlayer(GameObject dock)
    {
        
        playerPos = dock.transform.GetChild(0).transform;
        player.transform.position = playerPos.position;

        GetComponent<BoatStateController>().ChangeState(idleState);

        player.GetComponent<CharacterController>().enabled = true;


    }
}
