using UnityEngine;
using System.Collections;


public class CreateInventoryScript : MonoBehaviour {

	//------CLASSES-----------------------
	[System.Serializable]
	public class PivotClass : System.Object
	{
		[Range(1,50)]
		public int topSpacing = 20;
		[Range(1,50)]
		public int bottomSpacing = 20;
		[Range(1,50)]
		public int leftSpacing = 20;
		[Range(1,50)]
		public int rightSpacing = 20;

		[Range(1,50)]
		public int horizontalSpacing = 10;
		[Range(1,50)]
		public int verticalSpacing = 10;

	}

	[System.Serializable]
	public class DesignElementsClass : System.Object
	{
		public GameObject imagePrefab;
		public GameObject buttonPrefab;
		public Sprite normalBackground;
	}


	///------- Public Variables ------------------------------

	public int columns; //How many item slots are displayed horizontally
	public int rows; //the size of the space between the columns -> value = ratio of panel
	[Range(10,150)]
	public int slotSize; //the size of the slots
	[Range(10,150)]
	public int iconSize; //the size of the item icon. normally a bit smaller than the slot size

	public bool showPivotOptions = false;
	public PivotClass pivots;
	public bool showDesignOptions = false;
	public DesignElementsClass designElements;

	public bool displayCurrency = false;

	public string currencyName;
	public Sprite currencyImage;
	




	///--------- FUNCTIONS -------------------------------------
	//
	public void CreateInventory()
	{

		//Calculate the inventory window based on the public variables
		float slotWindowWidth = pivots.leftSpacing + (columns * slotSize) + ((columns-1) * pivots.verticalSpacing) + pivots.rightSpacing;
		float slotWindowHeight = pivots.topSpacing + (rows * slotSize) + ((rows-1) * pivots.horizontalSpacing) + pivots.bottomSpacing;
		gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2 (slotWindowWidth, slotWindowHeight);

		//Create the slots
		float positionX;
		float positionY = pivots.topSpacing + slotSize/2;
		for(int y = 0; y < rows; y++)
		{
			positionX = pivots.leftSpacing + slotSize/2;
			for(int x = 0; x < columns; x++)
			{
				//Instantiate
				GameObject slot = Instantiate(designElements.imagePrefab, transform.position, Quaternion.identity) as GameObject;
				slot.transform.SetParent(transform);
				slot.GetComponent<RectTransform>().sizeDelta = new Vector2(slotSize,slotSize);
				slot.GetComponent<RectTransform>().anchoredPosition = new Vector3(positionX, -positionY, 0);

				positionX = positionX + slotSize*1.0f + pivots.verticalSpacing;
			}

			positionY = positionY +slotSize*1.0f + pivots.horizontalSpacing;
		}
	}
	
}
