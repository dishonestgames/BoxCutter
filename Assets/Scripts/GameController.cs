using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject enemy;
	private static int enemiesKilled;
	private int timer;
	private int spawnCooldown;
	private float enemySpeed;
	private Vector3[] spawnPoints;

	// Use this for initialization
	void Start () {
		enemiesKilled = 0;
		spawnCooldown = 100;
		spawnPoints = new Vector3[]{
			new Vector3(-15.0f, 0.1f),
			new Vector3(15.0f, 0.1f),
			new Vector3(-15.0f, -3.9f),
			new Vector3(15.0f, -3.9f)
		};
		enemySpeed = 0.06f;
	}
	
	// Update is called once per frame
	void Update () {
		if (enemiesKilled == 5) {
			enemySpeed = 0.08f;
			spawnCooldown = 90;
		} else if (enemiesKilled == 10) {
			enemySpeed = 0.12f;
			spawnCooldown = 75;
		} else if (enemiesKilled == 15) {
			enemySpeed = 0.16f;
			spawnCooldown = 50;
		} else if (enemiesKilled == 20) {
			enemySpeed = 0.2f;
			spawnCooldown = 50;
		}
		timer++;
		if (timer >= spawnCooldown) {
			timer = 0;
			GameObject current = (GameObject) Instantiate(enemy, spawnPoints[Random.Range(0,4)], new Quaternion());
			current.GetComponent<Enemy> ().speed = enemySpeed;
		}
	}

	public static void addKill(){
		enemiesKilled++;
		Debug.Log (enemiesKilled);
	}

	public static void endGame(){
		Debug.Log ("PLAYER HAS DIED");
	}
}
