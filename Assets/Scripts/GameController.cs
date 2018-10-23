using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject enemy;

	// Use this for initialization
	void Start () {
        Instantiate(enemy, new Vector3(6.0f, -3.0f), new Quaternion());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
