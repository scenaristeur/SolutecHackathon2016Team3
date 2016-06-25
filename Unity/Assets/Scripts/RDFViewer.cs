using UnityEngine;
using System.Collections;

public class RDFViewer : MonoBehaviour {

    // Use this for initialization
    IEnumerator Start () {
        Debug.Log("start");
        WWW site = new WWW("http://unity3d.com/");
        yield return site;

        Debug.Log(site.text);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
