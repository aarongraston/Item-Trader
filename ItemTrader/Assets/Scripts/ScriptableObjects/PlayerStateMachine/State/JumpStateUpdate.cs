using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player State/State Update Methods/Jump State Update")]
public class JumpStateUpdate : StateUpdateMethod
{
    public State groundedState;
    Vector3 movement = Vector3.zero;

    public override void UpdateState(PlayerStateController controller)
    {
        Debug.Log(movement);
        Debug.Log(controller.charController.isGrounded);
        if (controller.charController.isGrounded)
        {
            movement = new Vector3(0, controller.variables.jumpSpeed, 0);
        }

        if (movement.y >= 0 && Input.GetButton("Jump") && controller.airTime > 0)
        {
            
            Vector3 movementKeys = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            movementKeys = movementKeys.normalized;
            movementKeys = movementKeys * Time.deltaTime * controller.variables.speed * controller.variables.movementInAirPercentage;
            movement.x = movementKeys.x;
            movement.z = movementKeys.z;

            movement.y = movement.y - controller.variables.gravity * Time.deltaTime;

            if (movement.y <= 0)
            {
                controller.airTime -= Time.deltaTime;
                movement.y = 0;
            }


            controller.charController.Move(movement);
            return;
        }

        if (!controller.charController.isGrounded)
            {
                Vector3 movementKeys = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
                movementKeys = movementKeys.normalized;
                movementKeys = movementKeys * Time.deltaTime * controller.variables.speed * controller.variables.movementInAirPercentage;
                movement.x = movementKeys.x;
                movement.z = movementKeys.z;


                movement.y = movement.y - controller.variables.gravity * Time.deltaTime;

            controller.charController.Move(movement);
                return;
            }

        if (controller.charController.isGrounded)
        {
            controller.airTime = controller.variables.timeAirStall;
            controller.currentState = groundedState;
        }
    }
    }

