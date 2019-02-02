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
            gravityAmount = 0.1f;
            movement.y = -0.01f;
        }
        else
        {
            gravityAmount = controller.variables.gravity;
            movement.y -= gravityAmount * Time.deltaTime;
        }

        controller.charController.Move(movement);

        if (movement.x != 0 || movement.z != 0)
        {
            Debug.Log(controller.charController.velocity.x);
            Debug.Log(controller.charController.velocity.z);

            if (Mathf.Abs(controller.charController.velocity.x) > 0.25 || Mathf.Abs(controller.charController.velocity.z) > 0.25)
            {
                controller.GetComponentInChildren<Animator>().SetBool("running", true);
            }
            else
            {
                controller.GetComponentInChildren<Animator>().SetBool("running", false);
            }

            controller.transform.rotation = Quaternion.Slerp(controller.transform.rotation, Quaternion.LookRotation(movementKeys), controller.variables.turnSpeed);
        }
        else
        {
            controller.GetComponentInChildren<Animator>().SetBool("running", false);
        }

    }
}
