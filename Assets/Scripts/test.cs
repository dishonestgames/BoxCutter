using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	//private Transform parentTransform;

    private const float speed = 1.0f;
    private const float fallSpeed = 1.0f;
    private Rigidbody2D rb;
    public Transform pCam;
    private bool falling;

	// Use this for initialization
	void Start () {
        //rb = this.gameObject.GetComponent<Rigidbody2D>();
        //parentTransform = gameObject.transform;
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

        this.gameObject.GetComponent<Transform>().position += new Vector3(moveHorizontal, fallSpeed, 0.0f);



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
