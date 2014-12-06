using UnityEngine;
using System.Collections;

public class TurnScript : MonoBehaviour {

	private int row;
	private int column;

	//---------------FUNCTIONS-------------------------------
	public void TurnSquare(){
		string squareName = gameObject.name;
		//Debug.Log (squareName.Substring (1, 1));
		row = int.Parse (squareName.Substring (1, 1)); //Get the second letter of the word and convert to string
		column = int.Parse (squareName.Substring (3, 1)); //Get the fourth letter of the word and convert to string

		animation.Play ();
	}
	
}
