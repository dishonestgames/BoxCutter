using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    private const float speed = 0.1f;
    private const float fallSpeed = 0.1f;
    public Transform pCam;

	void Start () {

	}

    private void Update()
    {
		CharacterController controller = GetComponent<CharacterController> ();
		controller.SimpleMove (new Vector3(0.0f,0.0f,0.0f));
    }

	void OnControllerColliderHit(ControllerColliderHit hit){
		Debug.Log ("hit");
	}
}
