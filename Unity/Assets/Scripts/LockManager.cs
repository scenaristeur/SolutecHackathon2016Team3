using UnityEngine;
using System.Collections;

public class LockManager : ObjectManager {


	public float distUnlockable = 1;
	public string color = "green";
	public Sprite[] sprites;

	// Use this for initialization
	void Start () {
		database = new RDF ();
		refreshData ();
	}
	
	// Update is called once per frame
	void Update () {
		GameObject bob = GameObject.Find ("Bob");
		float distFromPlayer = Mathf.Sqrt (Mathf.Pow(this.transform.position.x - GameObject.Find("Bob").transform.position.x, 2) 
			+ Mathf.Pow(this.transform.position.y - bob.transform.position.y, 2));
		if (distFromPlayer < this.distActivable) {
			isActionable = true;
		}
		if (Input.GetKeyDown ("e") && isActionable)
			refreshData ();

		if (Input.GetKeyDown ("a") && isActionable) {
			startTime = Time.time;
			StartCoroutine (OpenBrowser ());
		}
	}

	protected override void refreshData(){
		try{
			string dbcolor = database.getValue(this.gameObject.name,"couleur");
			if(dbcolor == "vert" || dbcolor == "jaune") {
				this.color = dbcolor;
			}
			if(this.color == "vert"){
				foreach(SpriteRenderer s in GetComponentsInChildren<SpriteRenderer> ())
					s.sprite = sprites [0];
			}
			else if (this.color == "jaune") {
				foreach(SpriteRenderer s in GetComponentsInChildren<SpriteRenderer> ())
					s.sprite = sprites [1];
			}
		}catch(System.FormatException ignored){
			Debug.Log (ignored.Message);
		}
	}
}
