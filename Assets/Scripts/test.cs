using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    private const float speed = 3.0f;
    private const float fallSpeed = 0.1f;
    public Transform pCam;
    public Sword sword;
    GlobalConsts.Orientation direction;

	void Start () {
        direction = GlobalConsts.Orientation.RIGHT;
        sword.SetSide(GlobalConsts.Orientation.RIGHT);
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
            if (direction == GlobalConsts.Orientation.LEFT) sword.SwitchSide();
            direction = GlobalConsts.Orientation.RIGHT;
        } 
        else if (moveHorizontal < 0)
        {
            if (direction == GlobalConsts.Orientation.RIGHT) sword.SwitchSide();
            direction = GlobalConsts.Orientation.LEFT;
        }
        
    }

	void OnControllerColliderHit(ControllerColliderHit hit){
	}
}
