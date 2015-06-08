using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public float speed;
	public Camera deathCamera;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.forward * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player"){
			//Camera.main.enabled = false;
			//deathCamera.enabled = true;
			DestroyObject(other.gameObject);
			DestroyObject(gameObject);
		}
	}
}
