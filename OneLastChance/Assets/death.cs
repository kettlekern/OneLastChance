using UnityEngine;
using System.Collections;

public class death : MonoBehaviour {
	public GameObject Death;
	public float timeTillDeath;
	private bool isDead;
	private float deadTime;
	public GameObject parent;

	// Use this for initialization
	void Start () {
		isDead = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isDead && deadTime < Time.fixedTime) {
			Destroy(parent);
		}
	}

	void OnTriggerEnter(Collider co) {
		if (co.gameObject.tag == "Bullet") {
			Death.GetComponent<AudioSource>().Play();
			Death.GetComponent<ParticleSystem>().Play();
			deadTime = Time.fixedTime + timeTillDeath;
			isDead = true;
		}
	}
}
