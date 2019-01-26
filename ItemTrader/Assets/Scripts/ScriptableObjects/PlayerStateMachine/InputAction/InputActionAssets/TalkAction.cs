using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player State/Actions/Talk")]
public class TalkAction : InputAction
{
    public bool talking = false;

    public override void Act(PlayerStateController controller)
    {
        talking = controller.talkingTo.GetComponent<Character>().ExecuteDialogue(controller.pointInDialogue);
        controller.pointInDialogue++;
        if (talking == false)
        {
            controller.pointInDialogue = 1;
        }
    }

    public override void Act(PlayerStateController controller, GameObject boat)
    {
        return;
    }
}
