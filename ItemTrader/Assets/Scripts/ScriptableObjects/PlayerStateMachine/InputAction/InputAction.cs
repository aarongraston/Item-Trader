﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputAction : ScriptableObject
{
    public abstract void Act(PlayerStateController controller);
}
