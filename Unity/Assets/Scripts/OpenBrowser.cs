using UnityEngine;
using System.Collections;

public class OpenBrowser : MonoBehaviour{
	public float smoothing = 1f;
	public Transform target;
	float startTime;
	string itemName;

	public OpenBrowser(string itemName){
		this.itemName = itemName;
	}

	void Start (){
		StartCoroutine (MyCoroutine ());
		startTime = Time.time;
	}

	IEnumerator MyCoroutine (){
		while (Time.time - startTime < 200) {
			yield return null;
		}
		Application.OpenURL("http://192.168.101.38/solutechackathon2016team3/Watch_graph/?object=" + this.itemName);
		yield return new WaitForSeconds (3f);
	}
}