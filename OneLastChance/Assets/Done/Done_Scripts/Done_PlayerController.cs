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
	public int health;
	private bool hasExploded = false;

//	void OnCollisionEnter (Collision col) {
//		if (col.collider.gameObject.tag == "Enemy" || col.collider.gameObject.tag == "Bullet") {
//			health--;
//		}
//	}

	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == "Bullet") {
			health--;
		}
	}
	
	void Update ()
	{
//		if (!Input.anyKeyDown && animateTimer > 10) {
//
//		}

		if (health <= 0) {
			ExplodeAndDie ();
		}
	}

	void FixedUpdate ()
	{
		if (!hasExploded) {
			float horizontalDir = Input.GetAxis ("Horizontal");
			float verticalDir = Input.GetAxis ("Vertical");
			float rotateDir = Input.GetAxis ("Rotate");

			this.gameObject.transform.Rotate (Vector3.up * rotateSpeed * rotateDir);

			Rigidbody rigidBody = GetComponent<Rigidbody> ();
			float sqrSpeed = rigidBody.velocity.sqrMagnitude;
			float sqrMaxVelocity = maxVelocity * maxVelocity;

			// braking
			if (sqrSpeed > sqrMaxVelocity) {
				float brakeSpeed = sqrSpeed - sqrMaxVelocity;
				Vector3 normalizedVelocity = rigidBody.velocity.normalized;
				Vector3 brakeVelocity = normalizedVelocity * brakeSpeed;

				rigidBody.AddForce (-brakeVelocity);
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

	void ExplodeAndDie() {
		if (!hasExploded) {
			GetComponent<Detonator> ().Explode ();
			hasExploded = true;
		}
		GameObject.FindGameObjectWithTag ("GameController").GetComponent<Done_GameController> ().lose ();
	}
}
