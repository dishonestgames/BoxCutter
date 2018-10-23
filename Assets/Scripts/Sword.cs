using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

    //[HideInInspector

    private Transform transform;
    public float offset = 1.0f;

	// Use this for initialization
	void Start () {
        transform = this.gameObject.GetComponent<Transform>();
        SetSide(test.Orientation.RIGHT);
	}
	
	// Update is called once per frame
	void Update () {
		//if 

	}

    public void SwitchSide()
    {
        float currentX = transform.localPosition.x;
        transform.localPosition = new Vector3(-currentX, 0.0f);
    }

    public void SetSide(test.Orientation o)
    {
        transform.localPosition = new Vector3((int)o * offset, 0.0f);
    }

}
