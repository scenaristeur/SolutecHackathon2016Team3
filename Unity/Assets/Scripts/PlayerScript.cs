using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public int speed = 50;
	public int jumpPower = 50;
	public bool canMove = true;
    int direction = 1;
    Animator animBob;
	// Use this for initialization
	void Start () {
        animBob = GetComponent<Animator>();
        //Application.OpenURL("http://192.168.101.39:3030");

    }
	
	// Update is called once per frame
	void Update () {
        float mouveHorizontal = 0;
        float mouveVertical = 0;
        mouveHorizontal = Input.GetAxis("Horizontal");
        mouveVertical = Input.GetAxis("Vertical");
        if (mouveHorizontal<0)
        {
            direction = -1;
        }
        if (mouveHorizontal > 0)
        {
            direction = 1;
        }
        
        canMove = true;
        if (Input.GetKeyDown("t"))
        {
            if(direction == 1)
                animBob.SetBool("hack", true);
            else
                animBob.SetBool("hackl", true);
            canMove = false;
        }
        else if (Input.GetKeyUp("t"))
        {
            canMove = true;
            animBob.SetBool("hack", false);
            animBob.SetBool("hackl", false);
        }
        if (canMove == true)
        {
            

            Vector2 mouvment = new Vector2(mouveHorizontal * speed, mouveVertical * jumpPower);
            GetComponent<Rigidbody2D>().AddForce(mouvment);
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

	void OnCollisionEnter()
	{
		canMove = true;
	}

	void OnCollisionExit()
	{
		canMove = false;
	}
}
