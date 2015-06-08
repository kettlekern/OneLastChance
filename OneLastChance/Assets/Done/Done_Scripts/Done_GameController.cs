using UnityEngine;
using System.Collections;

public class Done_GameController : MonoBehaviour
{
	public GUIText gameOverText;
	public string enemyName;
	public string friendlyName;
	
	private bool gameOver;
	private bool gameWin;
	
	void Start ()
	{
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

	public bool isWin(){
		return gameWin;
	}
}