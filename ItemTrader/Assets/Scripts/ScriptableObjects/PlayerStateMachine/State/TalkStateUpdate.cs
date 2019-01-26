using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player State/State Update Methods/Talk State Update")]
public class TalkStateUpdate : StateUpdateMethod
{
    public override void UpdateState(PlayerStateController controller)
    {
        controller.talkingTo.GetComponent<DialogueManager>().DisplayOverhead();
    }
}
