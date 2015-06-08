using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public float speed;
	public Camera deathCamera;
	private Done_GameController controller;


	// Use this for initialization
	void Start () {
		controller = GameObject.FindGameObjectWithTag ("GameController").GetComponent<Done_GameController>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.forward * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player"){
			//Camera.main.enabled = false;
			//deathCamera.enabled = true;
			controller.lose();
			DestroyObject(other.gameObject);
			DestroyObject(gameObject);
		}
	}
}
