using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Boat State/State Update Methods/Boat Active State Update")]
public class BoatActiveState : BoatStateUpdateMethod
{
    Vector3 movement = Vector3.zero;


    public override void UpdateState(BoatStateController controller)
    {
        Vector3 movementKeys = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        movementKeys = movementKeys.normalized;
        movementKeys = movementKeys * controller.variables.speed * Time.deltaTime;
        movement.x = movementKeys.x;
        movement.z = movementKeys.z;

        

       movement.y = 0 + Mathf.Sin(Time.time * controller.variables.floatSpeed) * controller.variables.floatStrength;

        controller.charController.Move(movement);

        if (movement.x != 0 || movement.z != 0)
        {
            controller.transform.rotation = Quaternion.Slerp(controller.transform.rotation, Quaternion.LookRotation(movementKeys), controller.variables.turnSpeed);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStateController>().transform.rotation =
                Quaternion.Slerp(controller.transform.rotation, Quaternion.LookRotation(movementKeys), controller.variables.turnSpeed);
        }


    }
}
