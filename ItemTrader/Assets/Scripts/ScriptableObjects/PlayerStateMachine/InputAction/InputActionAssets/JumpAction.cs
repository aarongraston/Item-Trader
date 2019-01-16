using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player State/Actions/Jump Action")]
public class JumpAction : InputAction
{

    public override void Act(PlayerStateController controller)
    {
        Jump(controller);
    }

    //here is the function to make the guy jump.
    private void Jump(PlayerStateController controller)
    {

    }

}
