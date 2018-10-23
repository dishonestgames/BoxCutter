using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public enum Orientation
    {
        RIGHT = 1,
        LEFT = -1
    };

    private const float speed = 4.0f;
	private const float jumpSpeed = 8.0f;
	private bool hasJumped = false;

	private Vector3 moveDirection = Vector3.zero;

	public Rigidbody rb;
    public Transform pCam;
    public Sword sword;

    Orientation orientation;

	void Start () {
		rb = GetComponent<Rigidbody> ();
        orientation = Orientation.RIGHT;
        sword.SetSide(Orientation.RIGHT);
	}

    private void FixedUpdate() {
		Vector3 prev = moveDirection;
		float moveHorizontal;
		float inputHorizontal = Input.GetAxis ("Horizontal");

		if (inputHorizontal > 0) { moveHorizontal = speed; }
		else if (inputHorizontal < 0) { moveHorizontal = -speed; }
		else{ moveHorizontal = 0; }

		if (moveHorizontal != 0) {
			moveDirection.x = moveHorizontal;
		} else {
			moveDirection.x = 0;
		}

		if (Input.GetButton ("Jump") && !hasJumped) {
			moveDirection.y = jumpSpeed;
			hasJumped = true;
		} else {
			moveDirection.y = rb.velocity.y;
		}

		// Sword Orientation
		if (moveHorizontal > 0){
			if (orientation == Orientation.LEFT) sword.SwitchSide();
			orientation = Orientation.RIGHT;
		} else if (moveHorizontal < 0){
			if (orientation == Orientation.RIGHT) sword.SwitchSide();
			orientation = Orientation.LEFT;
		}
			
		rb.velocity = moveDirection;
	}

	void OnCollisionEnter(Collision collision){
		// Check if collision happened at the bottom of the player
		// Make it so they can jump again if they touch the floor and not walls
		if (collision.contacts.Length > 0) {
			ContactPoint contact = collision.contacts [0];
			if (Vector3.Dot (contact.normal, Vector3.up) > 0.5) {
				hasJumped = false;
			}
		}
	}
}
