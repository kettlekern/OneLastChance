using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour {

		public string newGameScene;
		// Use this for initialization
		void Start () {

		}
		
		// Update is called once per frame
		void Update () {
			
		}
		
		public void ChangeToScene(){
			Application.LoadLevel(newGameScene);
			GameObject player = GameObject.FindGameObjectWithTag ("Player");
		}
	}

