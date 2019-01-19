using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player State/State Update Methods/Move State Update")]
public class MoveStateUpdate : StateUpdateMethod
{

    //here is where the code for player movement goes:
    public override void UpdateState(PlayerStateController controller)
    {
        
            Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            movement = movement.normalized;
        
        controller.charController.Move(movement * Time.deltaTime * controller.variables.speed);

        if (movement != Vector3.zero)
        controller.transform.rotation = Quaternion.Slerp(controller.transform.rotation, Quaternion.LookRotation(movement), controller.variables.turnSpeed);
    }
}
