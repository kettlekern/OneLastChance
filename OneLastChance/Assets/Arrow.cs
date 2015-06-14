using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {
	public GameObject cam;
	public GameObject sun;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Calculate the angle from the camera to the target
		Vector3 targetDir = sun.transform.position - cam.transform.position;
		Vector3 forward = cam.transform.up;
		targetDir.y = 0;
		float angle = Vector3.Angle(targetDir, forward);
		if (targetDir.x > 0)
		{
			angle = -angle;
		}
		transform.localRotation = Quaternion.Euler(0,0,angle);
	}
}
