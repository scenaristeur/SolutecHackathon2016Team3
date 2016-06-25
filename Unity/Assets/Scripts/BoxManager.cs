using UnityEngine;
using System.Collections;

public class BoxManager : MonoBehaviour {

	public Sprite[] sprites;
	public bool isActionable = false;

	private RDF database;

	// Use this for initialization
	void Start () {
		database = new RDF ();
	}

	// Update is called once per frame
	void Update () {
		float distFromPlayer = Mathf.Sqrt (Mathf.Pow(this.transform.position.x - GameObject.Find("Bob").transform.position.x, 2) 
			+ Mathf.Pow(this.transform.position.y - GameObject.Find("Bob").transform.position.y, 2));
		if (distFromPlayer < 3) {
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
		string tailleCaillou = "";
		try{
			tailleCaillou = database.getValue ("Caillou12","taille");
			this.transform.localScale = new Vector2(int.Parse(tailleCaillou) ,int.Parse(tailleCaillou));
		}catch(System.FormatException ignored){
			Debug.Log (ignored.Message);
			Debug.Log (tailleCaillou);
		}
	}
}
