using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    GameObject player;
    Transform transform;

	// Use this for initialization
	void Start () {
        transform = this.gameObject.transform;
        player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        // Move camera based on player x
        Vector3 playerPos = player.transform.position;
        transform.position = new Vector3(playerPos.x, transform.position.y, transform.position.z);

        // Return player to its position relative to the camera
        player.transform.localPosition = new Vector3(0.0f, player.transform.localPosition.y, 10.0f);
	}
}
