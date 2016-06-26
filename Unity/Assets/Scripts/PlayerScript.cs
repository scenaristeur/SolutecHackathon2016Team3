using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour {

	public int speed = 20;
	public int jumpPower = 310;
	public int maxSpeed = 5;
	bool jumping;
	public bool canMove = true;
    int direction = 1;
	bool hasYellowKey = false;

    Animator animBob;
    Vector2 spawn;

	float moveHorizontal;
	float moveVertical;

	public GameObject UIKey;

	// Use this for initialization
	void Start () {
        animBob = GetComponent<Animator>();
        //Application.OpenURL("http://192.168.101.39:3030");
        direction = 1;
        spawn = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		float horizontalAcceleration = 0;

		//handle key mapped
		if (Input.GetKeyDown ("a")) {
			animBob.SetBool ("hack", true);
			if (direction == 1)
				GetComponent<SpriteRenderer> ().flipX = false;
			else
				GetComponent<SpriteRenderer> ().flipX = true;
			canMove = false;
		} else if (Input.GetKeyDown ("e")) {
			canMove = true;
			animBob.SetBool ("hack", false);
		} else if (Input.GetKeyDown ("r"))
			transform.position = spawn;

		moveHorizontal = Input.GetAxis ("Horizontal");
		moveVertical = Input.GetAxis ("Vertical");

		if (moveHorizontal < 0)
            direction = -1;
		else if (moveHorizontal > 0)
            direction = 1;
       
		//if the player is not hacking 
        if (canMove == true)
        {
			//we check if we are touching a support to know if we are abble to jump from the top of it
			bool canJump = false;
			foreach (GameObject go in GameObject.FindGameObjectsWithTag("Support")) {
				if (GetComponent<Collider2D> ().IsTouching (go.GetComponent<Collider2D> ())) {
					canJump = true;
				}
			}
			if (canJump) {
				if (Input.GetKeyDown ("space"))//Jump
					moveVertical = jumpPower;
				if (moveHorizontal == 0)//Player stopping (can't stop in air)
					GetComponent<Rigidbody2D>().velocity = new Vector2(0,GetComponent<Rigidbody2D>().velocity.y);
			}

			//
			if(GetComponent<Rigidbody2D>().velocity.x <= maxSpeed && GetComponent<Rigidbody2D>().velocity.x >= -maxSpeed)
				horizontalAcceleration = moveHorizontal;

			Vector2 mouvment = new Vector2 (horizontalAcceleration * speed, moveVertical);
			GetComponent<Rigidbody2D> ().AddForce (mouvment);
        }
			
		if (horizontalAcceleration != 0)
        {
            animBob.SetBool("walk", true);
            if (direction == 1)
                GetComponent<SpriteRenderer>().flipX = false;
            else
                GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            animBob.SetBool("walk", false);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.collider.name == "Lost")
        {
            transform.position = spawn;
        }
        if(coll.collider.name == "Finnish")
        {
            //Fin du niveau
			SceneManager.LoadScene("menu");
        }
		if (coll.collider.name == "lock_1_1" && hasYellowKey) {
			if (coll.collider.GetComponent<LockManager> ().color == "jaune") {
				Object.Destroy (coll.collider.gameObject);
				this.hasYellowKey = false;
				UIKey.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 0);
			}
		}
    }

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.GetComponent<Collider2D>().name == "yellowKey") {
			this.hasYellowKey = true;
			//show the key in the UI
			UIKey.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 1);
			Object.Destroy (coll.gameObject);
		}
	}

}
