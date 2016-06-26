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
		
	}


}