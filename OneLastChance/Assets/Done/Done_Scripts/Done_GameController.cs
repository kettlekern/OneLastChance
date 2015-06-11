using UnityEngine;
using System.Collections;

public class Done_GameController : MonoBehaviour
{
	public GUIText gameOverText;
	public string enemyName;
	public string friendlyName;
	public float playerSpawnRadius;
	
	private bool gameOver;
	private bool gameWin;

	
	void Start ()
	{
		spawnPlayer ();
		gameOver = false;
		gameOverText.text = "";
	}
	
	private void GameOver (string winner)
	{
		gameOverText.text = "The " + winner;
		gameOver = true;
	}

	public bool isGameOver(){
		return gameOver;
	}

	public void lose(){
		GameOver (enemyName + " have won...");
		gameWin = false;
	}

	public void win(){
		GameOver (friendlyName + " has won!");
		gameWin = true;
    }

	public Vector3 randomPositionAroundCircle(Vector3 center, float radius) {
		float angle = Random.value * 360;
		Vector3 pos = new Vector3 (center.x + radius * Mathf.Sin (angle * Mathf.Deg2Rad), 
		                      center.y,
		                      center.z + radius * Mathf.Cos (angle * Mathf.Deg2Rad));
		return pos;
	}

	public void spawnPlayer() {
		GameObject sun = GameObject.FindGameObjectWithTag ("Sun");
		GameObject player = GameObject.FindGameObjectWithTag ("Player");

		Vector3 playerSpawnPos = randomPositionAroundCircle (sun.transform.position, playerSpawnRadius);
		player.transform.position = playerSpawnPos;
		player.transform.LookAt (sun.transform.position);

	}

	public bool isWin(){
		return gameWin;
	}
}