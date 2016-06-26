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
        float dirAxeHorizon = Input.GetAxis("Horizontal");

		if (dirAxeHorizon < 0)
            direction = -1;
		else if (dirAxeHorizon > 0)
            direction = 1;
        //Debug.Log(direction);
        if (Input.GetKeyDown("a"))
        {
            
            if(direction == 1)
                animBob.SetBool("hack", true);
            else if(direction == -1)
                animBob.SetBool("hackl", true);
            canMove = false;
            
        }
        else if (Input.GetKeyDown("e"))
        {
            canMove = true;
            animBob.SetBool("hack", false);
            animBob.SetBool("hackl", false);
        }

        if (canMove == true)
        {
			//we check if we are touching a support to know if we are abble to jump from the top of it
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
            if(direction == 1)
                animBob.SetBool("walk", true);
            else
                animBob.SetBool("walkl", true);
        }
        else
        {
            animBob.SetBool("walk", false);
            animBob.SetBool("walkl", false);
        }
    }
}
