using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {


	public int speed = 20;
	public int jumpPower = 300;
	public int maxSpeed = 5;
	bool jumping;
	public bool canMove = true;
    Animator animBob;
	// Use this for initialization
	void Start () {
        animBob = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		float mouveHorizontal = 0;
		float mouveVertical = 0;
		if (!jumping) {
			mouveVertical = 1;
			jumping = true;
		}
        canMove = true;
        if (Input.GetKeyDown("e"))
        {
            animBob.SetBool("hack", true);
            canMove = false;
        }
        else if(Input.GetKeyUp("e"))
        {
            canMove = true;
            animBob.SetBool("hack", false);
        }
        if (canMove == true) {
			if(GetComponent<Collider2D>().IsTouching(GameObject.Find("Ground").GetComponent<Collider2D>()) && Input.GetKeyDown("space"))
				mouveVertical = jumpPower;

			if(GetComponent<Rigidbody2D>().velocity.x <= maxSpeed && GetComponent<Rigidbody2D>().velocity.x >= -maxSpeed)
				mouveHorizontal = Input.GetAxis ("Horizontal");

			Vector2 mouvment = new Vector2 (mouveHorizontal * speed, mouveVertical);
			GetComponent<Rigidbody2D> ().AddForce (mouvment);
		}
        if (mouveHorizontal != 0)
        {
            animBob.SetBool("walk", true);
        }
        else
        {
//            animBob.SetBool("walk", false);
        }
        


	}
}
