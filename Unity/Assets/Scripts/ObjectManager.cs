using System;
using System.Collections;
using UnityEngine;

public abstract class ObjectManager :  MonoBehaviour
{
	protected float startTime;
	protected RDF database;
	public float distActivable = 2;
	protected bool isActionable = false;

	protected abstract void refreshData ();

	protected IEnumerator OpenBrowser (){
		while (Time.time - this.startTime < 2) {
			yield return null;
		}
		Application.OpenURL("http://192.168.101.38/solutechackathon2016team3/Watch_graph/?object=" + this.gameObject.name);
		yield return new WaitForSeconds (3f);
	}
}


