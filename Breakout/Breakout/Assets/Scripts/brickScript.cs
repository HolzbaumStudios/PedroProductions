using UnityEngine;
using System.Collections;

public class brickScript : MonoBehaviour {

	void OnCollisionEnter2D (Collision2D collidingObject)
	{
		Debug.Log ("Collision");
		Destroy (this.gameObject);
	}
}
