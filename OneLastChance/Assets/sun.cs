using UnityEngine;
using System.Collections;

public class sun : MonoBehaviour {
	
	private Done_GameController controller;
	private float timer;

	public float delay;

	// Use this for initialization
	void Start () {
		controller = GameObject.FindGameObjectWithTag ("GameController").GetComponent<Done_GameController>();
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (controller.isGameOver () && controller.isWin ()) {
			timer += Time.deltaTime;
			if (timer > delay){
				foreach(GameObject planet in GameObject.FindGameObjectsWithTag("Enemy")){
					DestroyObject(planet);
				}
			}
		}
	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Player") {
			GetComponent<ParticleSystem>().Play();
			foreach(GameObject planet in GameObject.FindGameObjectsWithTag("Death")){
				planet.GetComponent<ParticleSystem>().Play();
			}
			controller.win();
			DestroyObject(other.gameObject);
			Camera.main.GetComponent<AudioListener>().enabled = true;
		}
	}
}
