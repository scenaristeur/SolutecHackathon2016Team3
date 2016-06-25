using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public int speed = 20;
	public int jumpPower = 300;
	public int maxSpeed = 5;
	bool jumping;
	public bool canMove = true;
    int direction = 1;
    Animator animBob;
	// Use this for initialization
	void Start () {
        animBob = GetComponent<Animator>();
        //Application.OpenURL("http://192.168.101.39:3030");
        direction = 1;
    }
	
	// Update is called once per frame
	void Update () {
		float mouveHorizontal = 0;
		float mouveVertical = 0;
        mouveHorizontal = Input.GetAxis("Horizontal");

        if (mouveHorizontal < 0)
            direction = -1;
        else if (mouveHorizontal > 0)
            direction = 1;
        //Debug.Log(direction);
        if (Input.GetKeyDown("a"))
        {
            animBob.SetBool("hack", true);
            if (direction == 1)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            canMove = false;
            
        }
        else if (Input.GetKeyDown("e"))
        {
            canMove = true;
            animBob.SetBool("hack", false);
        }

        if (canMove == true)
        {
			//we check if we are touching a support to know if we are abble to jump
			bool canJump = false;
			foreach (GameObject go in GameObject.FindGameObjectsWithTag("Support"))
				if (GetComponent<Collider2D> ().IsTouching (go.GetComponent<Collider2D> ()) && transform.position.y <= go.GetComponent<Collider2D> ().transform.position.y)
					canJump = true;
			if(Input.GetKeyDown("space") && canJump)
				mouveVertical = jumpPower;

			if(GetComponent<Rigidbody2D>().velocity.x <= maxSpeed && GetComponent<Rigidbody2D>().velocity.x >= -maxSpeed)
				mouveHorizontal = Input.GetAxis ("Horizontal");

			Vector2 mouvment = new Vector2 (mouveHorizontal * speed, mouveVertical);
			GetComponent<Rigidbody2D> ().AddForce (mouvment);
        }

		
		
        if (mouveHorizontal != 0)
        {
            animBob.SetBool("walk", true);
            if (direction == 1)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            } 
            else
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
                
        }
        else
        {
            animBob.SetBool("walk", false);
        }
    }
}
