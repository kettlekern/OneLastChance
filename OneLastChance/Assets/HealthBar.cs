using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour {
	public Done_PlayerController player;
	private Slider slider;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Done_PlayerController> ();
		slider = gameObject.GetComponent<Slider> ();
		slider.maxValue = player.health;
		slider.value = player.health;
	}
	
	// Update is called once per frame
	void Update () {
		slider.value = player.health;
	}
}
