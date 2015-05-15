using UnityEngine;
using System.Collections;


public class CreateInventoryScript : MonoBehaviour {

	/// Public Variables
	[Tooltip("Drag and drop the inventory panel in here")]
	public GameObject inventorySlotsPanel; //Reference to the inventory panel
	[Tooltip("Drag and drop Background Panel Prefab in here. The prefab can be found in the folder Prefabs")]
	public GameObject slotBackgroundPanel; //Reference to the Background Slot prefab (found in prefabs)

	[Tooltip("Choose how many slots should be created per row")]
	[Range(1,10)]
	public int numberOfColumns; //How many item slots are displayed horizontally
	[Tooltip("The size of the spacing between the columns.")]
	[Range(0.05f,1)]
	public float columnSpacing; //the size of the space between the columns -> value = ratio of panel


	/// Private Variables
	private int slotWidth; //The widht of the item slots -> calculated during gameplay
	private int slotHeight; //The height of the item slots -> calculated during gameplay



	public void CreateInventory(){ //Creates the inventory

		//Get the columnsize and calculate the respective slot width and spacing
		float columnWidth = GetSlotSize (); 
		float slotWidth = columnWidth / (1+columnSpacing);
		float slotHeight = slotWidth;
		float slotSpacing = columnWidth - slotWidth;


		GameObject slot;
		float positionX = slotSpacing + slotWidth / 2;
		float positionY = slotSpacing + slotHeight / 2;

		for(int y = 0; y < 5; y++){ //Create the rows
			for(int x = 0; x < numberOfColumns; x++){ //Create the columns

				//Create the object
				slot = Instantiate (slotBackgroundPanel, transform.position, transform.rotation) as GameObject;
				slot.transform.SetParent(inventorySlotsPanel.transform);
				slot.GetComponent<RectTransform>().sizeDelta = new Vector2 (slotWidth, slotHeight);
				//slot.GetComponent<RectTransform>().rect.height = 2;

				Debug.Log ("X: " + positionX + " Y: " + positionY);
				//Set position;
				slot.GetComponent<RectTransform>().anchoredPosition = new Vector2(positionX, -positionY);

				//Set next xCoordinates
				positionX = positionX + slotSpacing + slotWidth;
			}

			positionX = slotSpacing + slotWidth / 2; //reset positionX
			positionY = positionY + slotSpacing + slotHeight;
		}



	}

	private float GetSlotSize(){
		float slotsPanelWidth = inventorySlotsPanel.GetComponent<RectTransform>().rect.width;
		//float slotsPanelHeight = inventorySlotsPanel.GetComponent<RectTransform>().rect.height;
	
		float columnWidth = (slotsPanelWidth - (slotsPanelWidth /numberOfColumns)*columnSpacing) / numberOfColumns; //minus column spacing because there will be one extra spacing at the beginning or end

		return columnWidth;
		
	}
}
