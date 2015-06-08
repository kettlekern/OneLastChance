﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class Done_Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class Done_PlayerController : MonoBehaviour
{
	public float thrustForce;
	public float maxVelocity;
	public float rotationForce;
	public float tilt;
	public Done_Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	 
	private float nextFire;
	
	void Update ()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			GetComponent<AudioSource>().Play ();
		}
	}

	void FixedUpdate ()
	{

		float rotateThrust = Input.GetAxis ("Horizontal") * rotationForce * Time.deltaTime;
		float forwardThrust = Input.GetAxis ("Vertical") * thrustForce * Time.deltaTime;
		if (forwardThrust > 0) {
			GetComponent<Rigidbody> ().AddRelativeForce (Vector3.forward * forwardThrust, ForceMode.VelocityChange);
		}
		GetComponent<Rigidbody> ().AddRelativeTorque (Vector3.up * rotateThrust, ForceMode.VelocityChange);
//		GetComponent<Rigidbody>().position = new Vector3
//		(
//			Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
//			0.0f, 
//			Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
//		);
		
		//GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}
}
