using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ItemDetection : MonoBehaviour
{
    public BoxCollider itemReach;

    private PlayerStateController psc;
    private GameObject closestItem;
    private List<GameObject> interactables = new List<GameObject>();

    public GameObject currentFocus;
    private bool bubbled = false;

    public GameObject bubble;
    public ItemVariables itemVars;

    
    // Start is called before the first frame update
    void Start()
    {
        itemReach = GetComponent<BoxCollider>();
        psc = GetComponentInParent<PlayerStateController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interactables.Count != 0) {
            if (FindClosest(interactables) != null)
            {
                closestItem = FindClosest(interactables);
            }
        }            
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9 || other.gameObject.tag == "character") {
            interactables.Add(other.gameObject);
            }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (interactables.Contains(other.gameObject)) {
            int index = interactables.IndexOf(other.gameObject);
            interactables.RemoveAt(index);
        }
    }

    public GameObject FindClosest(List<GameObject> array)
    {
        GameObject closest = null;

        float distance = Mathf.Infinity;
        Vector3 position = psc.gameObject.transform.position;
        foreach (GameObject obj in array)
        {
            if (obj == psc.itemRep)
                continue;

            Vector3 diff = obj.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = obj;
                distance = curDistance;
            }
        }
        if (currentFocus != closest)
        {
            FocusDisplay(closest);
        }
        return closest;
        
    }

    public void FocusDisplay(GameObject o) {
        if (o != currentFocus)
        {
            currentFocus = o;
            StartCoroutine(FocusBubbleHandler(o));
        }
        else {
            return;
        }
    }

    private IEnumerator FocusBubbleHandler(GameObject o) {
        
        yield return new WaitForSeconds(0.15f);

        //destroy all previous focus bubbles
        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag("bubble");
        foreach (GameObject obj in objectsToDestroy) {
            Destroy(obj);
        }

        GameObject bubbleInstance = Instantiate(
            bubble, 
            o.transform.position + new Vector3(0, o.transform.localScale.y / 2, 0), 
            o.transform.rotation, o.transform);

        Vector3 originalSize = bubbleInstance.transform.localScale;
        Vector3 originalPos = bubbleInstance.transform.position;

        bubbleInstance.transform.localScale = new Vector3(
            originalSize.x * itemVars.sizePercentage,
            originalSize.y * itemVars.sizePercentage,
            originalSize.z * itemVars.sizePercentage);

        Vector3 newSize = bubbleInstance.transform.localScale;


        float timeElapsed = 0f;

        while (currentFocus == o && 
            bubbleInstance.transform.localScale.x < originalSize.x &&
            bubbleInstance.transform.localScale.y < originalSize.y &&
            bubbleInstance.transform.localScale.z < originalSize.z && 
            bubbleInstance.transform.position.y < originalPos.y + itemVars.focusBubbleDistance) {
            timeElapsed += Time.deltaTime * itemVars.timePercentage;

            bubbleInstance.transform.localScale = Vector3.Lerp(newSize, originalSize, timeElapsed);
            bubbleInstance.transform.position = new Vector3(
                bubbleInstance.transform.position.x,
                Mathf.Lerp(originalPos.y, originalPos.y + itemVars.focusBubbleDistance, timeElapsed),
                bubbleInstance.transform.position.z);
            yield return null;
        }

        State talkingState = (State)AssetDatabase.LoadAssetAtPath("Assets/Scripts/ScriptableObjects/PlayerStateMachine/State/PlayerTalkState.asset", typeof(State));

        while (currentFocus == o) {

            if (o.gameObject.tag == "character" && psc.currentState == talkingState) {
                break;
            }
            timeElapsed += Time.deltaTime * itemVars.timePercentage;

            bubbleInstance.transform.Translate(
                0,
                Mathf.Cos(timeElapsed / Mathf.PI) * itemVars.floatDistance,
                0);
            yield return null;
        }

        Destroy(bubbleInstance);       
    } 



}
