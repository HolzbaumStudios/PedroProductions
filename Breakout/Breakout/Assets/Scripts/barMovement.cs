using UnityEngine;
using System.Collections;

public class barMovement : MonoBehaviour {

	public float paddleSpeed;
	private Vector3 playerPos = new Vector3 (0, -4.2f, 0);

	// Update is called once per frame
	void Update () {
		float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
		playerPos = new Vector3 (Mathf.Clamp (xPos, -6.6f, 6.6f), -4.2f, 0f);
		transform.position = playerPos;
	}
}
