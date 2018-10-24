using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject enemy;
	private int timer;
	private int spawnCooldown;
	private Vector3[] spawnPoints = {
		new Vector3(-15.0f, 0.1f),
		new Vector3(15.0f, 0.1f),
		new Vector3(-15.0f, -3.9f),
		new Vector3(15.0f, 3.9f)
	};

	// Use this for initialization
	void Start () {
		spawnCooldown = 50;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (Time.deltaTime);
		timer++;
		if (timer >= spawnCooldown) {
			timer = 0;
			GameObject current = (GameObject) Instantiate(enemy, spawnPoints[Random.Range(0,4)], new Quaternion());
			//current.GetComponent<Enemy> ().speed = 1.5f;
		}
	}
}
