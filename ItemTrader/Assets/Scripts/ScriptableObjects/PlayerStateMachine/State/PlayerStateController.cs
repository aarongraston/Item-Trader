using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    //public enum for this class, to be compared in other classes
    public enum ButtonPressed
    {
        Space, E, Nothing
    };
    public State currentState;
    [HideInInspector] public CharacterController charController;

    //private variables
    private ButtonPressed bPressed = ButtonPressed.Nothing;

    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);

        if (Input.GetButton("Space")) {
            bPressed = ButtonPressed.Space;
            currentState.DoAction(this, bPressed);
        }

        if (Input.GetButton("E"))
        {
            bPressed = ButtonPressed.E;
            currentState.DoAction(this, bPressed);
        }
    }
}
