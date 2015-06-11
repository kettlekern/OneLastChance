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
	private ParticleSystem fLeftTranslationJet;
	private ParticleSystem bLeftTranslationJet;
	private ParticleSystem fRightTranslationJet;
	private ParticleSystem bRightTranslationJet;

	private Done_PlayerController playerController;
	private Rigidbody playerRigidBody;
	private float xScaleFactor;
	private float zScaleFactor;
	// Use this for initialization
	void Start () {
		leftJet = GameObject.Find ("leftJet").GetComponent<ParticleSystem>();
		coreJet = GameObject.Find ("coreJet").GetComponent<ParticleSystem>();
		rightJet = GameObject.Find ("rightJet").GetComponent<ParticleSystem>();
		fLeftTranslationJet = GameObject.Find ("fltJet").GetComponent<ParticleSystem> ();
		bLeftTranslationJet = GameObject.Find ("bltJet").GetComponent<ParticleSystem> ();
		fRightTranslationJet = GameObject.Find ("frtJet").GetComponent<ParticleSystem> ();
		bRightTranslationJet = GameObject.Find ("brtJet").GetComponent<ParticleSystem> ();
		playerController = GameObject.FindGameObjectWithTag ("Player").GetComponent<Done_PlayerController> ();
		playerRigidBody = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Vertical") > 0) {
			coreJet.startSize = jetMaxStartSize;
			coreJet.startSpeed = jetMaxStartSpeed;
		} else {
			coreJet.startSize = jetMinStartSize;
			coreJet.startSpeed = jetMinStartSpeed;
		}

		if (Input.GetAxis ("Rotate") > 0) {
			leftJet.startSize = jetMaxStartSize;
			leftJet.startSpeed = jetMaxStartSpeed;
			rightJet.startSize = 0;
			rightJet.startSpeed = 0;
		} else if (Input.GetAxis ("Rotate") < 0) {
			rightJet.startSize = jetMaxStartSize;
			rightJet.startSpeed = jetMaxStartSpeed;
			leftJet.startSize = 0;
			leftJet.startSpeed = 0;
		} else {
			rightJet.startSize = 0;
			rightJet.startSpeed = 0;
			leftJet.startSize = 0;
			leftJet.startSpeed = 0;
		}

		if (Input.GetAxis ("Horizontal") > 0) {
			fLeftTranslationJet.startSize = jetMaxStartSize;
			fLeftTranslationJet.startSpeed = jetMaxStartSpeed;
			bLeftTranslationJet.startSize = jetMaxStartSize;
			bLeftTranslationJet.startSpeed = jetMaxStartSpeed;
		} else if (Input.GetAxis ("Horizontal") < 0) {
			fRightTranslationJet.startSize = jetMaxStartSize;
			fRightTranslationJet.startSpeed = jetMaxStartSpeed;
			bRightTranslationJet.startSize = jetMaxStartSize;
			bRightTranslationJet.startSpeed = jetMaxStartSpeed;
		} else {
			fLeftTranslationJet.startSize = 0;
			fLeftTranslationJet.startSpeed = 0;
			bLeftTranslationJet.startSize = 0;
			bLeftTranslationJet.startSpeed = 0;
			fRightTranslationJet.startSize = 0;
			fRightTranslationJet.startSpeed = 0;
			bRightTranslationJet.startSize = 0;
			bRightTranslationJet.startSpeed = 0;
		}

	}
}
