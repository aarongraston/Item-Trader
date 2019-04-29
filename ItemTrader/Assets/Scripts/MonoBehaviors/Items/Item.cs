using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private Rigidbody rb;

    public ItemVariables itemVars;

    private bool focussed = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moveToPlayer(Vector3 originalSize) {
        Transform playerItemPos = GameObject.FindGameObjectWithTag("Player").transform.FindDeepChild("ItemPosition");
        StartCoroutine(PickUpItem(playerItemPos, itemVars.timePercentage));
    }

    //this will move the item to the players hands, called indirectly from the moveToPlayer method

    private IEnumerator PickUpItem(Transform destination, float speed) {

        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStateController>().SetHoldingItem(
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStateController>().talkingTo.GetComponent<Character>().currentDialogue.itemToGive);

        transform.position = SetPlayerItem().position;
        transform.localPosition = transform.localPosition + new Vector3( 
            0,
            itemVars.spawnHeightOffset, 
            0);
       
        Vector3 startPos = this.transform.position;
        Transform itemDest = destination;
        Vector3 currentSize = this.transform.localScale;

        float timePassed = 0f;

        while (transform.position != itemDest.position) {
            timePassed += Time.deltaTime * speed;

            transform.position = Vector3.Lerp(startPos, itemDest.position, timePassed);
            yield return null;
        }

        rb.isKinematic = true;
        rb.useGravity = false;
    }

    public Transform SetPlayerItem() {
        Transform playerParent = GameObject.FindGameObjectWithTag("Player").transform.FindDeepChild("ItemPosition");
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStateController>().itemRep = gameObject;
        transform.SetParent(playerParent);
        return playerParent;
    }

    //for bumping the item from the player's hands

    public void Bump() {

        this.enabled = false;
        transform.parent = null;
        transform.position = GameObject.FindGameObjectWithTag("Player").transform.FindDeepChild("ItemDischarge").position;

        this.enabled = true;
        rb = gameObject.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = true;

        Vector3 force = new Vector3(Random.Range(0f, 1f), 0.2f, Random.Range(0, 1f));

        rb.AddForce(force, ForceMode.Impulse);     
    }

    //this will be used to start the hovering focus effect.
    public void SetFocus() {
        
    }

    
}
