using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player State/Actions/Talk")]
public class TalkAction : InputAction
{
    public State moveState;
    public bool talking = false;

    public override void Act(PlayerStateController controller)
    {
        talking = controller.talkingTo.GetComponent<Character>().ExecuteDialogue(controller.pointInDialogue);
        controller.pointInDialogue++;
        if (talking == false)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            controller.pointInDialogue = 0;
            //controller.destroyCurrentItem();
            //here is where the item is set and held
            //trigger end of conversation in player
            controller.endConversation();
            controller.currentState = moveState;
        }
    }

    public override void Act(PlayerStateController controller, GameObject boat)
    {
        return;
    }
}
