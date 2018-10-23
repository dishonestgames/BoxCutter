using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    private const float speed = 1.0f;
    private const float fallSpeed = 0.1f;
    public Transform pCam;

	void Start () {

	}

    private void Update()
    {
		float moveHorizontal;
		float input = Input.GetAxis ("Horizontal");
		if (input > 0) {
			moveHorizontal = speed;
		}else if (input < 0) {
			moveHorizontal = -speed;
		}else{
			moveHorizontal = 0;
		}
		CharacterController controller = GetComponent<CharacterController> ();
		controller.SimpleMove (new Vector3(moveHorizontal, 0.0f, 0.0f));
    }

	void OnControllerColliderHit(ControllerColliderHit hit){
	}
}
