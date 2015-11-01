using UnityEngine;
using System.Collections;

public class ballScript : MonoBehaviour {

	public float ballInitialVelocity = 600f;
	
	
	private Rigidbody2D rigBody;
	private bool ballInPlay = false;


	void Awake ()
	{
		rigBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown("Fire1") && ballInPlay == false)
		{
			Debug.Log("Fired");
			transform.parent = null;
			ballInPlay = true;
			rigBody.isKinematic = false;
			rigBody.AddForce(new Vector2(ballInitialVelocity, ballInitialVelocity));
		}
	}
}
