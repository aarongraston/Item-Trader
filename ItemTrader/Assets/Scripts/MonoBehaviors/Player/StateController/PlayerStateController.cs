using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    //public enum for this class, to be compared in other classes
   
    [HideInInspector] public State currentState;
    [HideInInspector] public CharacterController charController;
    [HideInInspector] public enum ButtonPressed { Space, E, Nothing};

    public PlayerVariables variables;

    public float airTime;

    //private variables
    private ButtonPressed bPressed = ButtonPressed.Nothing;

    // Start is called before the first frame update
    void Awake()
    {
        Init();
        airTime = variables.timeAirStall;

    }

    private void Init()
    {
        charController = GetComponent<CharacterController>();

        //if you want to change the state the player loads into at the start of the game (you will most likely for the sake of an intro), here is where to do it:
        currentState = (State)AssetDatabase.LoadAssetAtPath("Assets/Scripts/ScriptableObjects/PlayerStateMachine/State/PlayerMoveState.asset", typeof(State));
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);

        if (Input.GetButtonDown("Jump")) {
            bPressed = ButtonPressed.Space;
            currentState.DoAction(this, bPressed);
        }

        if (Input.GetButtonDown("Interact"))
        {
            bPressed = ButtonPressed.E;
            currentState.DoAction(this, bPressed);
        }
    }

    
}
