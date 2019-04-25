using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatStateController : MonoBehaviour
{
    GameObject player;
    public BoatVariables variables;
    public CharacterController charController;

    private BoatState currentState;

    // Start is called before the first frame update
    void start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        //there is no reason to pass the playerController, going to change this to boat, be right back...
        currentState.UpdateState(this);
    }

    public void ChangeState(BoatState state)
    {
        currentState = state;
    }

    }
