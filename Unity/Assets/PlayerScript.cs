using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public int speed = 50;
	public int jumpPower = 50;
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
        if (canMove == true) {
			mouveHorizontal = Input.GetAxis ("Horizontal");
            mouveVertical = Input.GetAxis ("Vertical");

			Vector2 mouvment = new Vector2 (mouveHorizontal * speed, mouveVertical * jumpPower);
			GetComponent<Rigidbody2D> ().AddForce (mouvment);
		}
        if (mouveHorizontal != 0)
        {
            animBob.SetBool("walk", true);
        }
        else
        {
            animBob.SetBool("walk", false);
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
