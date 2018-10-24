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

	private void OnTriggerEnter(Collider collision)
    {
		//Debug.Log(this.gameObject.transform.parent.name + " collided with " + collision.gameObject.name);
		//Debug.Log (collision.gameObject.tag + ", " + objectTagToCollideWith);
		if (collision.gameObject.tag == objectTagToCollideWith)
        {
			if (collision.gameObject.tag == "Enemy") {
				GameController.addKill ();
			} else if (collision.gameObject.tag == "Player") {
				GameController.endGame ();
			}
            Destroy(collision.gameObject);
        }
    }

}
