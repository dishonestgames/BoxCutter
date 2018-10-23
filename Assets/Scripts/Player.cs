using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public enum Orientation
    {
        RIGHT = 1,
        LEFT = -1
    };

    private const float speed = 1.0f;
    private const float fallSpeed = 0.1f;
    public Transform pCam;
    public Sword sword;

    Orientation orientation;

	void Start () {
        orientation = Orientation.RIGHT;
        sword.SetSide(Orientation.RIGHT);
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

        if (moveHorizontal > 0)
        {
            if (orientation == Orientation.LEFT) sword.SwitchSide();
            orientation = Orientation.RIGHT;
        } 
        else if (moveHorizontal < 0)
        {
            if (orientation == Orientation.RIGHT) sword.SwitchSide();
            orientation = Orientation.LEFT;
        }
    }

	void OnControllerColliderHit(ControllerColliderHit hit){
	}
}
