using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

    private Transform transform;
    public float offset = 1.0f;

	void Start () {
        transform = this.gameObject.GetComponent<Transform>();
        SetSide(Player.Orientation.RIGHT);
	}

	void Update () {

	}

    public void SwitchSide()
    {
        float currentX = transform.localPosition.x;
        transform.localPosition = new Vector3(-currentX, 0.0f);
    }

    public void SetSide(Player.Orientation o)
    {
        transform.localPosition = new Vector3((int)o * offset, 0.0f);
    }

}
