using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public float speed;

	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.forward * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player"){
			//DestroyObject(gameObject);
		}
	}
}
