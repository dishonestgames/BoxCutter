using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

    private Transform transform;
    public float offset = 1.0f;
    public string objectTagToCollideWith;

	// Use this for initialization
	void Start () {
        transform = this.gameObject.GetComponent<Transform>();
        SetSide(GlobalConsts.Orientation.RIGHT);
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void SwitchSide()
    {
        float currentX = transform.localPosition.x;
        transform.localPosition = new Vector3(-currentX, 0.0f);
    }

    public void SetSide(GlobalConsts.Orientation o)
    {
        transform.localPosition = new Vector3((int)o * offset, 0.0f);
        //Debug.Log("Sword Pos for " + gameObject.transform.parent.name + ": " + transform.localPosition);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with " + collision.gameObject.name);
        if (collision.gameObject.tag == objectTagToCollideWith)
        {
            Destroy(collision.gameObject);
        }
    }

}
