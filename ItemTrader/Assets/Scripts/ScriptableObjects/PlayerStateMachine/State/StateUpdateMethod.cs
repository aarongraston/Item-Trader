using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class StateUpdateMethod : ScriptableObject
{
    public abstract void UpdateState(PlayerStateController controller);

}
