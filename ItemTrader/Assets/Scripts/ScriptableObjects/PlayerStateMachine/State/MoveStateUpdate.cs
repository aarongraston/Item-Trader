using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player State/State Update Methods/Move State Update")]
public class MoveStateUpdate : StateUpdateMethod
{
    float gravityAmount = 0f;
    Vector3 movement = Vector3.zero;

    //here is where the code for player movement goes:
    public override void UpdateState(PlayerStateController controller)
    {
            
            Vector3 movementKeys = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            movementKeys = movementKeys.normalized;
        movementKeys = movementKeys * Time.deltaTime * controller.variables.speed;

        movement.x = movementKeys.x;
        movement.z = movementKeys.z;

        if (controller.charController.isGrounded)
        {
            gravityAmount = 0f;
            movement.y = 0;
        }
        else
        {
            gravityAmount = controller.variables.gravity;
            movement.y -= gravityAmount * Time.deltaTime;
        }
        
        controller.charController.Move(movement);

        if (movement != Vector3.zero)
        controller.transform.rotation = Quaternion.Slerp(controller.transform.rotation, Quaternion.LookRotation(movementKeys), controller.variables.turnSpeed);
    }
}
