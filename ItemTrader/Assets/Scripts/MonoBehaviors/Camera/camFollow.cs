using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camFollow : MonoBehaviour
{
    public GameObject player;
    private Vector3 distanceOut;
    public float smoothSpeed = 0.125f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        distanceOut = this.transform.position;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPosition = new Vector3(
            player.transform.position.x + distanceOut.x, 
            player.transform.position.y + distanceOut.y, 
            player.transform.position.z + distanceOut.z);

        Vector3 smoothPosition = Vector3.Lerp(transform.position, newPosition, smoothSpeed);


        transform.position = smoothPosition;
    }
}
