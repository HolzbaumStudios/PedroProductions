using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {

	//--------------Variables----------------
	int fieldRows = 4;
	int fieldColumns = 5;
	float squareSpace = Screen.width/14; //The spacing between the squares  --> otherwise 120
	float squareSize = Screen.width/15;

	public GameObject squareObject;

	//-----------------CLASSES---------------
	public class cSquareClass{
		public GameObject squareObject;
		public int squareState = 0; //States: 0 = no Square, 1 = wrongSide, 2 = rightSide

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
				yPosition = -difference * squareSpace + squareSpace/2;
			}else{
				float halfField = fieldRows / 2;
				float difference = halfField - i;
				yPosition = -difference * squareSpace;
			}


			//Create the field columns
			for (int j = 0; j < fieldColumns; j++){
				//Calculate Placement.
				//Create the square
				GameObject column = Instantiate(squareObject,transform.position,transform.rotation) as GameObject;
				squareArray[i,j].squareObject = column;
				column.transform.parent = GameObject.Find ("squarePanel").transform;
				column.name = "r"+i+"c" +j;
				//Set position regarding width count
				if(evenNumberWidth)
				{
					float halfField = fieldColumns / 2;
					float difference = halfField - j;
					column.GetComponent<RectTransform>().anchoredPosition = new Vector2(-difference * squareSpace + squareSpace/2,yPosition);
				}else{
					float halfField = fieldColumns / 2;
					float difference = halfField - j;
					column.GetComponent<RectTransform>().anchoredPosition = new Vector2(-difference * squareSpace,yPosition);
				}
				//Set size of the square
				column.GetComponent<RectTransform>().sizeDelta = new Vector2(squareSize,squareSize);
			}

		}
	}



	//Turn the squares around the klicked square
	public void TurnOtherSquares(string squareName){
		int row;
		int column;
		int tempRow;
		int tempColumn;
		row = int.Parse (squareName.Substring (1, 1)); //Get the second letter of the word and convert to string
		column = int.Parse (squareName.Substring (3, 1)); //Get the fourth letter of the word and convert to string

		//TopRow
		//Square top left
		tempRow = row + 1;
		tempColumn = column -1;
		if(tempRow >= 0 && tempRow < fieldRows && tempColumn >=0 && tempColumn < fieldColumns){
			int squareState = CheckSquareState (tempRow,tempColumn); //Get the new square value
			squareArray[tempRow,tempColumn].squareObject.SendMessage("TurnSquare", squareState); //Turn the square with the new value
		}
		//Square top middle
		tempRow = row + 1;
		tempColumn = column;
		if(tempRow >= 0 && tempRow < fieldRows && tempColumn >=0 && tempColumn < fieldColumns){
			int squareState = CheckSquareState (tempRow,tempColumn); //Get the new square value
			squareArray[tempRow,tempColumn].squareObject.SendMessage("TurnSquare", squareState); //Turn the square with the new value
		}
		//Square top right
		tempRow = row + 1;
		tempColumn = column + 1;
		if(tempRow >= 0 && tempRow < fieldRows && tempColumn >=0 && tempColumn < fieldColumns){
			int squareState = CheckSquareState (tempRow,tempColumn); //Get the new square value
			squareArray[tempRow,tempColumn].squareObject.SendMessage("TurnSquare", squareState); //Turn the square with the new value
		}
		//Middle ROw
		//Square middle left
		tempRow = row;
		tempColumn = column -1;
		if(tempRow >= 0 && tempRow < fieldRows && tempColumn >=0 && tempColumn < fieldColumns){
			int squareState = CheckSquareState (tempRow,tempColumn); //Get the new square value
			squareArray[tempRow,tempColumn].squareObject.SendMessage("TurnSquare", squareState); //Turn the square with the new value
		}
		//Square middle middle
		tempRow = row;
		tempColumn = column;
		if(tempRow >= 0 && tempRow < fieldRows && tempColumn >=0 && tempColumn < fieldColumns){
			int squareState = CheckSquareState (tempRow,tempColumn); //Get the new square value
			squareArray[tempRow,tempColumn].squareObject.SendMessage("TurnSquare", squareState); //Turn the square with the new value
		}
		//Square middle right
		tempRow = row;
		tempColumn = column + 1;
		if(tempRow >= 0 && tempRow < fieldRows && tempColumn >=0 && tempColumn < fieldColumns){
			int squareState = CheckSquareState (tempRow,tempColumn); //Get the new square value
			squareArray[tempRow,tempColumn].squareObject.SendMessage("TurnSquare", squareState); //Turn the square with the new value
		}
		//Bottom ROw
		//Square bottom left
		tempRow = row-1;
		tempColumn = column -1;
		if(tempRow >= 0 && tempRow < fieldRows && tempColumn >=0 && tempColumn < fieldColumns){
			int squareState = CheckSquareState (tempRow,tempColumn); //Get the new square value
			squareArray[tempRow,tempColumn].squareObject.SendMessage("TurnSquare", squareState); //Turn the square with the new value
		}
		//Square bottom middle
		tempRow = row-1;
		tempColumn = column;
		if(tempRow >= 0 && tempRow < fieldRows && tempColumn >=0 && tempColumn < fieldColumns){
			int squareState = CheckSquareState (tempRow,tempColumn); //Get the new square value
			squareArray[tempRow,tempColumn].squareObject.SendMessage("TurnSquare", squareState); //Turn the square with the new value
		}
		//Square bottom right
		tempRow = row-1;
		tempColumn = column + 1;
		if(tempRow >= 0 && tempRow < fieldRows && tempColumn >=0 && tempColumn < fieldColumns){
			int squareState = CheckSquareState (tempRow,tempColumn); //Get the new square value
			squareArray[tempRow,tempColumn].squareObject.SendMessage("TurnSquare", squareState); //Turn the square with the new value
		}

	}

	//Checks the state of the square and change it accordingly
	int CheckSquareState(int row, int column){
		if(squareArray[row,column].squareState == 0){
			squareArray[row,column].SetSquareState(1);
		}else if(squareArray[row,column].squareState == 1){
			squareArray[row,column].SetSquareState(0);
		}

		return squareArray[row,column].squareState;
	}



}
