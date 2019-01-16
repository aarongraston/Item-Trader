using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player State/State")]
public class State : ScriptableObject
{
    //this will be set in the inspector
    public InputAction[] inputActions; 

        public void UpdateState(PlayerStateController controller)
    {

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
}
