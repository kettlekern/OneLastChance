using UnityEngine;
using System.Collections;

public class aim : MonoBehaviour {

	public Transform target;
	public Transform head;
	public float delay;
	public float timeSinceShot;
	public Transform LaunchPoint;
	public GameObject bulletPrefab;
	public float rotationSpeed;
	private float timeSinceLooked;
	public float lookDelay;
	private Quaternion lookTarget; 

	// Use this for initialization
	void Start () {
		timeSinceShot = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (target != null) {
			//Vector3 targetPoint = new Vector3(target.position);
			head.rotation = Quaternion.Lerp (head.rotation, playerLocation (), Time.deltaTime * rotationSpeed);
			timeSinceShot += Time.deltaTime;
			if (delay < timeSinceShot) {
				Instantiate (bulletPrefab, LaunchPoint.position, LaunchPoint.rotation);
				GetComponent<AudioSource> ().Play ();
				timeSinceShot = 0;
			}
		} else {
			timeSinceLooked += Time.deltaTime;
			if (timeSinceLooked > lookDelay){
				lookTarget = randomLocation();
				timeSinceLooked = 0;
			}
			head.rotation = Quaternion.Lerp (head.rotation, lookTarget, Time.deltaTime * rotationSpeed);
		}
	}

	public Quaternion randomLocation()
	{
		Quaternion rotation = Random.rotation;
		return new Quaternion(head.rotation.x, rotation.y, head.rotation.z, rotation.w);
	}

	public Quaternion playerLocation()
	{
		return new Quaternion(head.rotation.x, Mathf.Atan((target.position.z-head.position.z) / (target.position.x-head.position.x)), head.rotation.z, head.rotation.w);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			target = other.gameObject.transform;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.transform == target) {
			target = null;
		}
	}
}
