using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player State/Actions/Interact")]
public class InteractAction : InputAction
{
    public State nextState;

    public override void Act(PlayerStateController controller)
    {
        return;      
    }

    public override void Act(PlayerStateController controller, GameObject boat)
    {
        boatCall(controller, boat);

    }

    public void boatCall(PlayerStateController controller, GameObject boat)
    {
        RaycastHit hit;
        controller.StandingOn(out hit);
        controller.currentState = nextState;

        if (hit.transform.gameObject == GameObject.FindWithTag("dock"))
        {
            boat.GetComponent<CheckandLoadPlayer>().LoadPlayer();
        }

    }


}
