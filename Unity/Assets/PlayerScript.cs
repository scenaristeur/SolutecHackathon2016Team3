using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public int speed = 5;
	public int jumpPower = 300000;
	public int maxSpeed = 5;
	bool jumping;

	// Use this for initialization
	void Start () {
		jumping = false;
	}
	
	// Update is called once per frame
	void Update () {
		float mouveHorizontal = 0;
		float mouveVertical = 0;
		if (!jumping) {
			mouveVertical = 1;
			jumping = true;
		}

		if(GetComponent<Collider2D>().IsTouching(GameObject.Find("Ground").GetComponent<Collider2D>()) && Input.GetKeyDown("space"))
			mouveVertical = jumpPower;
		
		if(GetComponent<Rigidbody2D>().velocity.x <= maxSpeed && GetComponent<Rigidbody2D>().velocity.x >= -maxSpeed)
			mouveHorizontal = Input.GetAxis ("Horizontal");

		Vector2 mouvment = new Vector2 (mouveHorizontal * speed, mouveVertical*6);
		GetComponent<Rigidbody2D>().AddForce (mouvment);
	}
}
