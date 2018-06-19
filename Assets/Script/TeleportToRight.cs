using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToRight : MonoBehaviour {

    public GameObject targetCube = null;

    public GameObject player = null;

    private bool startTeleport = false;
    Vector3 newPos = new Vector3(9.62f, -3.360001f, -0.0314405f);
    // Use this for initialization
    void Start () {
        startTeleport = false;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (startTeleport)
        {

            player.transform.position = newPos;

            startTeleport = false;
            
        }

	}


    private void OnTriggerEnter(Collider other)
    {
        startTeleport = true;
    }
}
