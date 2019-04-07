using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public bool playerInRange = false;
    public DialogueObject nullDialogue;
    public DialogueObject[] dialogue;
    public DialogueObject currentDialogue;

    public GameObject itemStartPos;

    public bool LookForItem(ItemObject item)
    {

        foreach ( DialogueObject d in dialogue)
        {
            //dialogue objects need a conditional object to compare the passed in item to. (this needs to be fixed)
            if (d.conditionalItem == item)
            {
                currentDialogue = d;
                return true;
            }
        }

        currentDialogue = nullDialogue;
        return false;
        

    }

    public bool ExecuteDialogue(int i)
    {
        DialogueManager dManager = GetComponent<DialogueManager>();
        if (i >= currentDialogue.Dialogue.Length)
        {
            dManager.DisableCanvas(); 
            return false;
        }

        dManager.UpdateText(currentDialogue.Dialogue[i]);
        return true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInRange = true; 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInRange = false;
        }
    }

    public bool CheckTrigger()
    {
        return playerInRange; 
    }

    public void instanceItem(PlayerStateController pc) {

        GameObject item = Instantiate(currentDialogue.itemToGive.item, itemStartPos.transform.position, Quaternion.identity, itemStartPos.transform);
        Vector3 originalSize = item.transform.localScale;
        item.transform.localScale = new Vector3(
            item.transform.localScale.x * item.GetComponent<Item>().itemVars.sizePercentage,
            item.transform.localScale.y * item.GetComponent<Item>().itemVars.sizePercentage,
            item.transform.localScale.z * item.GetComponent<Item>().itemVars.sizePercentage
            );

        
        item.GetComponent<Item>().moveToPlayer(originalSize);

    }


}
