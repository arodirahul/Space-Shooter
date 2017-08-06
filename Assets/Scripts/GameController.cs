using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public GameObject hazard,hazard2;
	public Vector3 spawnValues;
	public int hazardCount;  
	public float spawnWait;
	public float startWait;
	public Text scoreText;
	public Text restartText;
	public Text gameOverText;
	private int score;
	private bool gameOver;
	private bool restart;


	void Start()
	{
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
		//SpawnWaves ();
		}

	void Update()
	{
		if (restart) 
		{
			if(Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	
	}

	IEnumerator SpawnWaves()
	//void SpawnWaves()
	{
		while(true){
		for (int i = 0; i < hazardCount; i++) {
			yield return new WaitForSeconds(startWait); //to let the player get ready
						Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), Random.Range (-spawnValues.y, spawnValues.y), spawnValues.z);
				Vector3 spawnPosition2 = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), Random.Range (-spawnValues.y, spawnValues.y), spawnValues.z);
						Quaternion spawnRotation2 = Quaternion.identity;
				Quaternion spawnRotation = Quaternion.identity;
						Instantiate (hazard, spawnPosition, spawnRotation);
				Instantiate (hazard2, spawnPosition2, spawnRotation2);
			yield return new WaitForSeconds(spawnWait);
				}
			if(gameOver)
			{
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
		yield return new WaitForSeconds(startWait);

	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}
	 void UpdateScore ()
	{
		scoreText.text = "Score :" + score;
	}

	public void GameOver()
	{
		gameOverText.text = "Game Over";
		gameOver = true;


		}
}
