using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {

	//--------------Variables----------------
	int fieldRows = 4;
	int fieldColumns = 5;

	public GameObject squareObject;

	//-----------------CLASSES---------------
	public class cSquareClass{
		GameObject squareObject;
		int squareState = 1; //States: 0 = no Square, 1 = wrongSide, 2 = rightSide

		public int GetSquareState()
		{
			return squareState;
		}

		public void SetSquareState(int newState){
			squareState = newState;
		}
	}

	//----------------CLASS Object----------
	cSquareClass[,] squareArray;

	//-------------------------START--------------------------------
	void Start () {
		InitializeArray (fieldRows, fieldColumns); //Initializes the array
		PrepareField (); //Prepares the field with the buttons
	}
	
	// Update is called once per frame
	void Update () {

	}


	//-------------FUNCTIONS-------------------------------
	void InitializeArray(int rows, int columns){
		squareArray = new cSquareClass[rows, columns];

		//Initialize the Array
		for(int i = 0; i < rows; i++)
		{
			for(int j = 0; j < columns; j++)
			{	
				squareArray[i,j] = new cSquareClass();
			}
		}
	}

	//Set all the fields
	void PrepareField(){

		bool evenNumberWidth = false;
		bool evenNumberHeight = false;


		//Check if Width and Height is even
		if(fieldRows%2==0){
			evenNumberHeight = true;
		} 
		if (fieldColumns % 2 == 0) {
			evenNumberWidth = true;
		}

		//Create Field Rows
		for (int i = 0; i < fieldRows; i++) {
			float yPosition; //Stores the height of the square
			if(evenNumberHeight)
			{
				float halfField = fieldRows / 2;
				float difference = halfField - i;
				yPosition = -difference * 120 + 60;
			}else{
				float halfField = fieldRows / 2;
				float difference = halfField - i;
				yPosition = -difference * 120;
			}


			//Create the field columns
			for (int j = 0; j < fieldColumns; j++){
				//Calculate Placement.
				//Create the square
				GameObject column = Instantiate(squareObject,transform.position,transform.rotation) as GameObject;
				column.transform.parent = GameObject.Find ("squarePanel").transform;
				column.name = "r"+i+"c" +j;
				//Set position regarding width count
				if(evenNumberWidth)
				{
					float halfField = fieldColumns / 2;
					float difference = halfField - j;
					column.GetComponent<RectTransform>().anchoredPosition = new Vector2(-difference * 120 + 60,yPosition);
				}else{
					float halfField = fieldColumns / 2;
					float difference = halfField - j;
					column.GetComponent<RectTransform>().anchoredPosition = new Vector2(-difference * 120,yPosition);
				}
			}

		}
	}







}
