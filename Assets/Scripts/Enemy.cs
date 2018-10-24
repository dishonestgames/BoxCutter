using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour {

    private Transform transform;
    Transform player;
    public float speed = 0.08f;
    private const float MIN_DISTANCE = 1.0f;
    public Sword sword;
    GlobalConsts.Orientation direction;

	// Use this for initialization
	void Start () {
        transform = this.gameObject.GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        direction = GlobalConsts.Orientation.RIGHT;
        //sword = this.gameObject.GetComponentInChildren<Sword>();
        //sword.SetSide(GlobalConsts.Orientation.RIGHT);
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 move = new Vector3();

        Vector3 toPlayer = player.transform.position - transform.position;
        float dx = toPlayer.x;

        //Debug.Log(dx);
        if (Mathf.Abs(dx) > MIN_DISTANCE)
        {

            move = Vector3.Normalize(new Vector3(dx, 0.0f)) * speed;
        }
        
        transform.position += move;

        if (move.x > 0.0f)
        {
            if (direction == GlobalConsts.Orientation.LEFT) sword.SwitchSide();
            direction = GlobalConsts.Orientation.RIGHT;
        }
        else if (move.x < 0.0f)
        {
            if (direction == GlobalConsts.Orientation.RIGHT) sword.SwitchSide();
            direction = GlobalConsts.Orientation.LEFT;
        }

    }
}
