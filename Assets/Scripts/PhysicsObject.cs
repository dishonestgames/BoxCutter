using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        this.gameObject.GetComponent<Transform>().position -= new Vector3(0.0f, 1.0f, 0.0f);
	}
}
