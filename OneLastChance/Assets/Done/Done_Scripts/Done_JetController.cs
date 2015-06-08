using UnityEngine;
using System.Collections;

public class Done_JetController : MonoBehaviour {
	public float jetMinStartSpeed;
	public float jetMinStartSize;
	public float jetMaxStartSpeed;
	public float jetMaxStartSize;

	private ParticleSystem leftJet;
	private ParticleSystem coreJet;
	private ParticleSystem rightJet;
	private Done_PlayerController playerController;
	private Rigidbody playerRigidBody;
	private float scaleFactor;
	// Use this for initialization
	void Start () {
		leftJet = GameObject.Find ("leftJet").GetComponent<ParticleSystem>();
		coreJet = GameObject.Find ("coreJet").GetComponent<ParticleSystem>();
		rightJet = GameObject.Find ("rightJet").GetComponent<ParticleSystem>();
		playerController = GameObject.FindGameObjectWithTag ("Player").GetComponent<Done_PlayerController> ();
		playerRigidBody = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		scaleFactor = (playerRigidBody.velocity.magnitude / playerController.maxVelocity);
		coreJet.startSize = jetMinStartSize + ((jetMaxStartSize - jetMinStartSize) * scaleFactor);
		coreJet.startSpeed = jetMinStartSpeed + ((jetMaxStartSpeed - jetMinStartSpeed) * scaleFactor);
	}
}
