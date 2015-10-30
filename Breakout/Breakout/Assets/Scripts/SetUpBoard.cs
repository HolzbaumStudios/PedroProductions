using UnityEngine;
using System.Collections;

public class SetUpBoard : MonoBehaviour {

	private float screenWidth = Screen.width;
	private float screenHeight = Screen.height;

	private float playerWidth;
	private float playerHeight;

	public GameObject playerPrefab;
	private GameObject player;

	// Use this for initialization
	void Start () {
		playerWidth = screenWidth / 10;
		playerHeight = screenHeight / 10;

		player = Instantiate (playerPrefab, new Vector2 (Screen.width / 2, Screen.height / 15), Quaternion.identity) as GameObject;
		player.transform.localScale = new Vector3 (playerWidth, playerHeight, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
