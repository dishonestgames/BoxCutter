using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	Transform parentTransform;

	// Use this for initialization
	void Start () {
		parentTransform = gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.D)) {
			parentTransform.position = parentTransform.position + new Vector3 (1, 0);
		}else if (Input.GetKey(KeyCode.A)) {
			parentTransform.position = parentTransform.position + new Vector3 (-1, 0);
		}
	}
}
