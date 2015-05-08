using UnityEngine;
using System.Collections;


public class CreateInventoryScript : MonoBehaviour {

	/// Public Variables
	[Tooltip("Drag and drop the inventory panel in here")]
	public GameObject inventorySlots; //Reference to the inventory panel
	[Tooltip("Drag and drop Background Panel Prefab in here. The prefab can be found in the folder Prefabs")]
	public GameObject backgroundPanel; //Reference to the Background Slot prefab (found in prefabs)

	[Tooltip("Choose how many slots should be created per row")]
	[Range(1,10)]
	public int numberOfColumns; //How many item slots are displayed horizontally
	public float columnSpacing; //	


	/// Private Variables
	private int slotWidth; //The widht of the item slots -> calculated during gameplay
	private int slotHeight; //The height of the item slots -> calculated during gameplay



	public void CreateInventory(){ //Creates the inventory
		GameObject slot;

		slot = Instantiate (backgroundPanel, transform.position, transform.rotation);
	}
}
