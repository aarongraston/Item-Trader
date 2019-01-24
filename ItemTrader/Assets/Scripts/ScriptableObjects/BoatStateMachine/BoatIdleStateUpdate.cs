using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Boat State/State Update Methods/Idle State")]
public class BoatIdleStateUpdate : BoatStateUpdateMethod
{
    Vector3 movement = Vector3.zero;


    public override void UpdateState(BoatStateController controller)
    {
        movement.y = 0 + Mathf.Sin(Time.time * controller.variables.floatSpeed) * controller.variables.floatStrength;

        controller.charController.Move(movement);
    }

    }
