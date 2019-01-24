using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Boat State/Boat State")]
public class BoatState : ScriptableObject
{
    public BoatStateUpdateMethod stateUpdate;

    public void UpdateState(BoatStateController controller)
    {
        stateUpdate.UpdateState(controller);
    }
}
