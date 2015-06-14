using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public float speed;
	public float bulletDamage;

	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.forward * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player"){
			DestroyObject(gameObject);
			other.gameObject.GetComponent<Done_PlayerController>().health -= bulletDamage;
		}
	}
}
