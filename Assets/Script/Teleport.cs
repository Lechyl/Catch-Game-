using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    public GameObject targetCube = null;

    public GameObject player = null;

    private bool startTeleport = false;
    public Vector3 newPos = new Vector3(0f,0f,0f); // The new position

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (startTeleport) // if player has Collided with this Object then startTeleport = true, then this If statement Activate
        {
            player.transform.position = newPos; // Transport Player to new Position

            startTeleport = false; // reset startTeleport

        }

    }


    private void OnTriggerEnter(Collider other) // if player Collide with this Object then Transport/Teleport
    {
        startTeleport = true;
    }
}


