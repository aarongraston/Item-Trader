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
    [HideInInspector] public float airTime;
    [HideInInspector] public int pointInDialogue = 0;
    [HideInInspector] public GameObject talkingTo;

    public ItemObject item;
    public PlayerVariables variables;
    public GameObject boat; 

    

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

    private void Update()
    {

        if (Input.GetButtonDown("Jump"))
        {
            bPressed = ButtonPressed.Space;
            currentState.DoAction(this, bPressed);
        }

        if (Input.GetButtonDown("Interact"))
        {
            bPressed = ButtonPressed.E;

            if (boat.GetComponent<CheckandLoadPlayer>().playerIsInTrigger)
            {      
                currentState.DoAction(this, bPressed, boat);
                return;
            }
            
            currentState.DoAction(this, bPressed);
        }
        
    }

    public void FixedUpdate()
    {
        currentState.UpdateState(this);
    }

    //a method that returns the raycast hit of what the player is standing on
    public void StandingOn(out RaycastHit returnHit)
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out returnHit, 5f))
        {
            return;
        }
    }

    //a method that returns the closest dock to the player
    public GameObject FindClosest(GameObject[] array)
    {
        GameObject closest = null;

        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject obj in array)
        {
            Vector3 diff = obj.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = obj;
                distance = curDistance;
            }
        }
        return closest;
    }


}
