using UnityEngine;
using System.Collections;

public class BoxManager : ObjectManager {

	public Sprite[] sprites;
    public int level;//Niveau dans lequel se trouve la box
    public int num;//Numero de la box dans le niveau
	private bool isMovable;
	private bool hasYellowKey;

	// Use this for initialization
	void Start () {
		database = new RDF ();
		refreshData ();
	}

	// Update is called once per frame
	void Update () {
		float distFromPlayer = Mathf.Sqrt (Mathf.Pow(this.transform.position.x - GameObject.Find("Bob").transform.position.x, 2) 
			+ Mathf.Pow(this.transform.position.y - GameObject.Find("Bob").transform.position.y, 2));
		if (distFromPlayer < this.distActivable) {
			GetComponent<SpriteRenderer> ().sprite = sprites [1];
			isActionable = true;
		} else {
			GetComponent<SpriteRenderer> ().sprite = sprites [0];
			isActionable = false;
		}

		if (Input.GetKeyDown ("e") && isActionable)
			refreshData ();
		
		if (Input.GetKeyDown ("a") && isActionable) {
			startTime = Time.time; 
			StartCoroutine (OpenBrowser ());
		}
	}

	protected override void refreshData(){
		int tailleBoite = 0;
		try{
			tailleBoite = int.Parse(database.getValue (this.gameObject.name,"taille"));
			this.transform.localScale = new Vector2(tailleBoite ,tailleBoite);
			this.distActivable = tailleBoite + 2;
			this.isMovable = bool.Parse(database.getValue(this.gameObject.name, "deplacable"));
			GetComponent<Rigidbody2D>().isKinematic = !this.isMovable;
		}catch(System.FormatException ignored){
			Debug.Log (ignored.Message);
		}
	}
}
