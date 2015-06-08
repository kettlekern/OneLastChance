using UnityEngine;
using System.Collections;

public class Done_GameController : MonoBehaviour
{
	public GUIText gameOverText;
	public string enemyName;
	public string friendlyName;
	
	private bool gameOver;
	
	void Start ()
	{
		gameOver = false;
		gameOverText.text = "";
	}
	
	private void GameOver (string winner)
	{
		gameOverText.text = "The " + winner + " have won...";
		gameOver = true;
	}

	public bool isGameOver(){
		return gameOver;
	}

	public void lose(){
		GameOver (enemyName);
	}

	public void win(){
		GameOver (friendlyName);
	}
}