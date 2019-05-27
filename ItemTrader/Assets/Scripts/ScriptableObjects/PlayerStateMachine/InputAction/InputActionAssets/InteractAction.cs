using System.Collections;
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
        ItemDetection itemDetection = FindObjectOfType<ItemDetection>();

        //here if in range of a character and the character is the object of focus

        if (character.GetComponent<Character>().CheckTrigger() && itemDetection.currentFocus.gameObject.tag == "character")
        {
            controller.charAnimator.SetBool("running", false);
            character.GetComponent<Character>().LookForItem(controller.item);

            //set whether to give an item here.
            controller.talkingTo = character;
            character.GetComponent<Character>().ExecuteDialogue(0);
            DialogueManager dManager = controller.talkingTo.GetComponent<DialogueManager>();
            dManager.EnableCanvas();
            controller.pointInDialogue++;
            controller.currentState = talkState;
        }

        //here if the object of focus is an item

        else if (itemDetection.currentFocus.gameObject.layer == 9) {
            itemDetection.currentFocus.GetComponent<Item>().moveToPlayer(new Vector3(1, 1, 1));
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
            controller.charAnimator.SetBool("inBoat", false);
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
            controller.charAnimator.SetBool("inBoat", true);
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
            controller.currentState = moveState;

        }
        

    } 

    


}
