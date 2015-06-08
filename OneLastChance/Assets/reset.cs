using UnityEngine;
using System.Collections;

public class reset : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.GetComponent<Camera>().enabled && Input.GetMouseButtonDown (0)) {
			Application.LoadLevel("Done_Main");
		}
	}


}
