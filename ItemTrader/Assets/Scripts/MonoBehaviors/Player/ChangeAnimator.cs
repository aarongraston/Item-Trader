using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnimator : MonoBehaviour
{
    public void SwitchAnimator(Controller newAnimator)
    {
        //destory the current animator
        GameObject animatorGoesHere = GetComponentInChildren<Animator>().gameObject;
        Destroy(GetComponentInChildren<Animator>());
        Animator anim = animatorGoesHere.AddComponent<Animator>();
        anim = newAnimator;
    }
}
