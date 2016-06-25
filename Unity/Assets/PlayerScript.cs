using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public int speed = 50;
	public int jumpPower = 50;
	public bool canMove = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (canMove) {
			float mouveHorizontal = Input.GetAxis ("Horizontal");
			float mouveVertical = Input.GetAxis ("Vertical");

			Vector2 mouvment = new Vector2 (mouveHorizontal * speed, mouveVertical * jumpPower);
			GetComponent<Rigidbody2D> ().AddForce (mouvment);
		}
	}

	void OnCollisionEnter()
	{
		canMove = true;
	}

	void OnCollisionExit()
	{
		canMove = false;
	}
}
