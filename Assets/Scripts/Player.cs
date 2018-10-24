using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Rigidbody rb;
	public Transform pCam;
	public Sword sword;

    private const float speed = 4.0f;
	private const float jumpSpeed = 7.0f;
	private bool hasJumped = false;
	private Vector3 moveDirection = Vector3.zero;

	private int weaponCooldown = 20;
	private int weaponTimer = 0;
	private bool isWeaponOut = false;

    GlobalConsts.Orientation orientation;

	private void setSwordActive(bool active){
		if (active) {
			sword.gameObject.SetActive (true);
			sword.objectTagToCollideWith = "Enemy";
		} else {
			sword.gameObject.SetActive (false);
		}
	}

	void Start () {
        orientation = GlobalConsts.Orientation.RIGHT;
        sword.SetSide(GlobalConsts.Orientation.RIGHT);
		rb = GetComponent<Rigidbody> ();
		setSwordActive(false);
	}

    private void FixedUpdate() {
		// Get horizontal movement
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

		// Check if the player jumped
		if (Input.GetButton ("Jump") && !hasJumped) {
			moveDirection.y = jumpSpeed;
			hasJumped = true;
		} else {
			moveDirection.y = rb.velocity.y;
		}

		// Sword Orientation
		if (moveHorizontal > 0){
			if (orientation == GlobalConsts.Orientation.LEFT) sword.SwitchSide();
			orientation = GlobalConsts.Orientation.RIGHT;
		} else if (moveHorizontal < 0){
			if (orientation == GlobalConsts.Orientation.RIGHT) sword.SwitchSide();
			orientation = GlobalConsts.Orientation.LEFT;
		}

		if (!isWeaponOut && Input.GetKeyDown (KeyCode.DownArrow)) {
			isWeaponOut = true;
			setSwordActive(true);
		} else if (isWeaponOut) {
			weaponTimer++;
			if (weaponTimer >= weaponCooldown) {
				weaponTimer = 0;
				isWeaponOut = false;
				setSwordActive(false);
			}
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
			if(Vector3.Dot (contact.normal, Vector3.left) > 0.5 || Vector3.Dot (contact.normal, Vector3.right) > 0.5 )
			{
				hasJumped = false;
			}
		}
    }
}
