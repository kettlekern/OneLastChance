using UnityEngine;
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
	public float rotateSpeed;
	public float backwardsThrustProportion;
	public bool onlyRotation;
	
	void Update ()
	{
	}

	void FixedUpdate ()
	{
		float horizontalDir = Input.GetAxis ("Horizontal");
		float verticalDir = Input.GetAxis ("Vertical");
		float rotateDir = Input.GetAxis ("Rotate");

		this.gameObject.transform.Rotate (Vector3.up * rotateSpeed * rotateDir);

		Rigidbody rigidBody = GetComponent<Rigidbody> ();
		float sqrSpeed = rigidBody.velocity.sqrMagnitude;
		float sqrMaxVelocity = maxVelocity * maxVelocity;

		// braking
		if(sqrSpeed > sqrMaxVelocity) {
			float brakeSpeed = sqrSpeed - sqrMaxVelocity;
			Vector3 normalizedVelocity = rigidBody.velocity.normalized;
			Vector3 brakeVelocity = normalizedVelocity * brakeSpeed;

			rigidBody.AddForce(-brakeVelocity);
		}

		if (verticalDir < 0) {
			rigidBody.AddRelativeForce (Vector3.forward * verticalDir * thrustForce * backwardsThrustProportion, ForceMode.Impulse);
		} else {
			rigidBody.AddRelativeForce (Vector3.forward * verticalDir * thrustForce, ForceMode.Impulse);
		}
		if (!onlyRotation) {
			rigidBody.AddRelativeForce (Vector3.right * horizontalDir * thrustForce, ForceMode.Impulse);
		}
	}
}
