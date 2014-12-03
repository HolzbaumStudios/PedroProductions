using UnityEngine;
using System.Collections;

public class waterMovement : MonoBehaviour {
	private bool startMovement; //Only start updatefunction if this is set to true
	private float initialPosition; //stores the initial position of the water on the y axis
	private float storePosition; //Stores the position based on Lerp, before writing it to vector3
	private float movementSpeed = 0.02f;
	private bool movingUp = true; //Determine if tile is moving up or down

	// Use this for initialization
	void Start () {
		initialPosition = transform.position.y; //get the initial height of the object
		StartCoroutine(StartDelay ()); 
	}
	
	// Update is called once per frame
	void Update () {
		if (startMovement) {
			if (movingUp) {
					transform.Translate (Vector3.up * Time.deltaTime * movementSpeed);
					if (transform.position.y > initialPosition + 0.04f) {
							movingUp = false;
					}
			} else {
					transform.Translate (Vector3.down * Time.deltaTime * movementSpeed);
					if (transform.position.y < initialPosition - 0.01f) {
							movingUp = true;
					}
			}
		}
	}

	//Wait until Start
	IEnumerator StartDelay() {
		float delayTime = Random.Range (-0.1F, 1.5F);
		yield return new WaitForSeconds(delayTime);
		startMovement = true;
	}
}
