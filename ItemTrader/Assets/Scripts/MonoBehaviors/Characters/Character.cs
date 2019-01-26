using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{

    DialogueObject nullDialogue;
    DialogueObject[] dialogue;

    public bool LookForItem(ItemObject item)
    {
        foreach ( DialogueObject d in dialogue)
        {
            if (d.item == item)
            {
                ExecuteDialogue(d);
                return true;
            }
        }
        return false;

    }

    private void ExecuteDialogue(DialogueObject d)
    {

    }
}
