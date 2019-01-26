﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Player State/Actions/Interact")]
public class InteractAction : InputAction
{
    public State boatState;
    public State moveState;
    public State talkState;

    public override void Act(PlayerStateController controller)
    {
        GameObject[] characters = GameObject.FindGameObjectsWithTag("character");
        GameObject character = controller.FindClosest(characters);
        if (character.GetComponent<Character>().CheckTrigger())
        {
            character.GetComponent<Character>().LookForItem(controller.item);
            controller.talkingTo = character;
            character.GetComponent<Character>().ExecuteDialogue(0);
            controller.pointInDialogue++;
            controller.currentState = talkState;
        }
    }

    public override void Act(PlayerStateController controller, GameObject boat)
    {
        if (controller.currentState == AssetDatabase.LoadAssetAtPath("Assets/Scripts/ScriptableObjects/PlayerStateMachine/State/PlayerMoveState.asset", typeof(ScriptableObject)) &&
            boat.GetComponent<CheckandLoadPlayer>().playerIsInTrigger)
        {
            boatCall(controller, boat);
            return;
        }

        if (controller.currentState == AssetDatabase.LoadAssetAtPath("Assets/Scripts/ScriptableObjects/PlayerStateMachine/State/PlayerBoatState.asset", typeof(ScriptableObject)) && 
            boat.GetComponent<CheckandLoadPlayer>().boatIsNearDock)
        boatUncall(controller, boat);

    }

    public void boatCall(PlayerStateController controller, GameObject boat)
    {
        RaycastHit hit;
        controller.StandingOn(out hit);
        GameObject theDock;
        GameObject[] docks = GameObject.FindGameObjectsWithTag("dock");

        theDock = controller.FindClosest(docks);

        if (hit.transform.gameObject == theDock)
        {
            controller.currentState = boatState;
            boat.GetComponent<CheckandLoadPlayer>().LoadPlayer();
        }

    }

    public void boatUncall(PlayerStateController controller, GameObject boat)
    {
        RaycastHit hit;
        controller.StandingOn(out hit);
        GameObject theDock;
        GameObject[] docks = GameObject.FindGameObjectsWithTag("dock");

        theDock = controller.FindClosest(docks);

        if (hit.transform.gameObject == GameObject.FindGameObjectWithTag("boat"))
        {
            boat.GetComponent<CheckandLoadPlayer>().UnloadPlayer(theDock);
            controller.currentState = moveState;        }
        

    } 

    


}
