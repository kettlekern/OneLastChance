using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform playerTransform;
	// Use this for initialization
	void Start () {
		playerTransform = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
	}

	// Update is called once per frame
	void Update () {
		if (playerTransform != null) {
			gameObject.transform.position = new Vector3 (playerTransform.position.x, gameObject.transform.position.y, playerTransform.position.z);
		} else {
			Destroy(gameObject);
		}
	}
}
