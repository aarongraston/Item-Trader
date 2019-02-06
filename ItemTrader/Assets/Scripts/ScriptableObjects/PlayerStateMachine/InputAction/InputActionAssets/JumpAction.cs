using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player State/Actions/Jump Action")]
public class JumpAction : InputAction
{
    public State nextState;

    public override void Act(PlayerStateController controller)
    {
        if (controller.charController.isGrounded)
        {
            Jump(controller);
            controller.GetComponentInChildren<Animator>().SetBool("isGrounded", false);
            controller.GetComponentInChildren<Animator>().SetTrigger("jumpTrigger");
        }
    }

    public override void Act(PlayerStateController controller, GameObject boat)
    {
        return;
    }

    //here is the function to make the guy jump.
    private void Jump(PlayerStateController controller)
    {
        controller.currentState = nextState;

    }

}
