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
	public GameObject targetGO;
	public float velocityGuess;
	private Done_GameController controller;

	// Use this for initialization
	void Start () {
		controller = GameObject.FindGameObjectWithTag ("GameController").GetComponent<Done_GameController>();
		timeSinceShot = 0;
		lookTarget = randomLocation();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (target != null && !controller.isGameOver()) {
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
			if (timeSinceLooked > lookDelay * 2){
				lookTarget = randomLocation();
				timeSinceLooked = Random.value;
			}
			head.rotation = Quaternion.Lerp (head.rotation, lookTarget, Time.deltaTime * rotationSpeed);
		}
	}

	public Quaternion randomLocation()
	{
		Quaternion rotation = Random.rotation;
		return new Quaternion(head.rotation.x, rotation.y, head.rotation.z, head.rotation.w);
	}

	public Quaternion playerLocation()
	{
		Vector3 vectorToTarget = (target.position + targetGO.GetComponent<Rigidbody>().velocity * velocityGuess) - transform.position;
		//Vector3 vectorToTarget = target.position - transform.position;
		float angle = Mathf.Atan2(vectorToTarget.x, vectorToTarget.z) * Mathf.Rad2Deg;
		return Quaternion.AngleAxis(angle, Vector3.up);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			target = other.gameObject.transform;
			targetGO = other.gameObject;
			timeSinceShot = delay/2;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.transform == target) {
			target = null;
			targetGO = null;
		}
	}
}
