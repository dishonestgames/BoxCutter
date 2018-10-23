using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    //private Transform parentTransform;

    public enum Orientation
    {
        RIGHT = 1,
        LEFT = -1
    };

    private const float speed = 1.0f;
    private const float fallSpeed = 1.0f;
    private Rigidbody2D rb;
    public Transform pCam;
    private bool falling;
    public Sword sword;

    Orientation orientation;

	// Use this for initialization
	void Start () {
        //rb = this.gameObject.GetComponent<Rigidbody2D>();
        //parentTransform = gameObject.transform;
        orientation = Orientation.RIGHT;
        sword.SetSide(Orientation.RIGHT);
        falling = true;
	}

    void FixedUpdate()
    {
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");

        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);

        //rb.AddForce(movement * speed);

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = (falling) ? -fallSpeed : 0.0f;

        this.gameObject.GetComponent<Transform>().position += new Vector3(moveHorizontal, /*fallSpee*/0.0f, 0.0f);

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

    private void Update()
    {
        falling = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts.Length > 0)
        {
            ContactPoint contact = collision.contacts[0];
            if (Vector3.Dot(contact.normal, Vector3.up) > 0.5)
            {
                falling = false;
            }
        }
    }

}
