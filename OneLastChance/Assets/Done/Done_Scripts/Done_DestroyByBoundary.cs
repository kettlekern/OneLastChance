﻿using UnityEngine;
using System.Collections;

public class Done_DestroyByBoundary : MonoBehaviour
{
	void OnTriggerExit (Collider other) 
	{
		if (other.gameObject.tag == "Bullet") {
			Destroy (other.gameObject);
		}
	}
}