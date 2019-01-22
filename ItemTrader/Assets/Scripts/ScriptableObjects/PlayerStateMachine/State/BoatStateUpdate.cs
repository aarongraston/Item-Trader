using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player State/State Update Methods/Boat State Update")]
public class BoatStateUpdate : StateUpdateMethod
{
    public override void UpdateState(PlayerStateController controller)
    {
        Transform playerPos = controller.boat.transform.GetChild(0);
        controller.transform.position = playerPos.position;
    }
}
