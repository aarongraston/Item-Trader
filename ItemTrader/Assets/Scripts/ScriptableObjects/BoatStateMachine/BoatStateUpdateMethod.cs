using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BoatStateUpdateMethod : ScriptableObject
{
    public abstract void UpdateState(BoatStateController controller);
}
