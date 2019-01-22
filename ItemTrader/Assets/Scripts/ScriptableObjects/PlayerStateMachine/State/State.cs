using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player State/State")]
public class State : ScriptableObject
{
    //the specifics on which update function and which actions on command are set in the inspector per State! :D very pluggable.
    public StateUpdateMethod stateUpdate;
    public InputAction[] inputActions; 

        public void UpdateState(PlayerStateController controller)
    {
        stateUpdate.UpdateState(controller);
    }

    public void DoAction(PlayerStateController controller, PlayerStateController.ButtonPressed bPressed)
    {
        if (bPressed == PlayerStateController.ButtonPressed.E)
        {
            inputActions[(int)bPressed].Act(controller);
        }

        if (bPressed == PlayerStateController.ButtonPressed.Space)
        {
            inputActions[(int)bPressed].Act(controller);
        }
    }

    public void DoAction(PlayerStateController controller, PlayerStateController.ButtonPressed bPressed, GameObject boat)
    {
        if (bPressed == PlayerStateController.ButtonPressed.E)
        {
            inputActions[(int)bPressed].Act(controller, boat);
        }

        if (bPressed == PlayerStateController.ButtonPressed.Space)
        {
            inputActions[(int)bPressed].Act(controller);
        }


    }


}
