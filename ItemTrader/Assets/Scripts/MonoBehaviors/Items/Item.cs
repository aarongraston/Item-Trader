using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private Rigidbody rb;

    public ItemVariables itemVars;

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
        StartCoroutine(Movement(playerItemPos, originalSize, itemVars.timePercentage));
    }

    public IEnumerator Movement(Transform destination, Vector3 originalSize, float speed) {

        Vector3 startPos = this.transform.position;
        Transform itemDest = destination;
        Vector3 sizeTarget = originalSize;
        Vector3 currentSize = this.transform.localScale;

        float timePassed = 0f;

        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStateController>().SetHoldingItem(
    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStateController>().talkingTo.GetComponent<Character>().currentDialogue.itemToGive);

        while (transform.position != itemDest.position) {
            timePassed += Time.deltaTime * speed;

            transform.position = Vector3.Lerp(startPos, itemDest.position, timePassed);
            transform.localScale = Vector3.Lerp(currentSize, sizeTarget, timePassed);
            yield return null;
        }

        Transform playerParent = GameObject.FindGameObjectWithTag("Player").transform.FindDeepChild("ItemPosition");

        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStateController>().itemRep = gameObject;
        this.transform.SetParent(playerParent);
    }

    public void Bump() {

        transform.parent = null;
        rb = gameObject.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = true;

        Vector3 force = new Vector3(Random.Range(0f, 1f), 0.2f, Random.Range(0, 1f));

        rb.AddForce(force, ForceMode.Impulse);     
    }
}
