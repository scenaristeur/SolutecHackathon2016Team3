using UnityEngine;
using System.Collections;

public class BoxManager : MonoBehaviour {

	public Sprite[] sprites;
	public bool isActionable = false;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		float distFromPlayer = Mathf.Sqrt (Mathf.Pow(GameObject.Find("boxCrate").transform.position.x - GameObject.Find("Player").transform.position.x, 2) 
			+ Mathf.Pow(GameObject.Find("boxCrate").transform.position.y - GameObject.Find("Player").transform.position.y, 2));
		if (distFromPlayer < 5) {
			GetComponent<SpriteRenderer> ().sprite = sprites [1];
			isActionable = true;
		} else {
			GetComponent<SpriteRenderer> ().sprite = sprites [0];
			isActionable = false;
		}

		if (Input.GetKeyDown ("e") && isActionable)
			refreshData ();

	}

	void refreshData(){
		Debug.Log ("refreshing");
	}
}
