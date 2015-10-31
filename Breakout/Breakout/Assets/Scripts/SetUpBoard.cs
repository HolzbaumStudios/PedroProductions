using UnityEngine;
using System.Collections;

public class SetUpBoard : MonoBehaviour {

	private Vector2 playerSize = new Vector2(20,2);
	private Vector2 brickSize = new Vector2(12, 2);


	public GameObject playerPrefab;
	public GameObject brickPrefab;
	private GameObject player;

	private int brickColumns = 8; //Always use an even number
	private int brickRows = 2;
	private int brickAmount = 24; //Alway use an even number

	// Use this for initialization
	void Start ()
	{
		SetUpPlayer ();
		SetBoard ();
	}
	
	void SetUpPlayer()
	{
		player = Instantiate (playerPrefab, new Vector2 (0,-4.2f), Quaternion.identity) as GameObject;
		player.transform.localScale = playerSize;
	}

	void SetBoard()
	{
		float brickXSpacing = 2;
		float brickYSpacing = 0.5f;
		float newXPosition = 1;
		float newYPosition = 4;
		int numberOfColumns = 0;
		for (int i = 0; i < brickAmount/2; i++)
		{
			numberOfColumns += 2; 
			GameObject brick = Instantiate (brickPrefab, new Vector2 (newXPosition,newYPosition), Quaternion.identity) as GameObject;
			brick.transform.localScale = brickSize;
			brick = Instantiate (brickPrefab, new Vector2 (-newXPosition,newYPosition), Quaternion.identity) as GameObject;
			brick.transform.localScale = brickSize;
			//Set new xposition
			newXPosition += brickXSpacing;
			//If reached maximum of columns, change row
			if(numberOfColumns >= brickColumns)
			{
				newYPosition -= brickYSpacing;
				numberOfColumns = 0;
				newXPosition = 1;
			}
		}
	}

}
