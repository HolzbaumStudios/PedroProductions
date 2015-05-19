using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(CreateInventoryScript))]
public class CreateInventoryEditor : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector(); //Use this if the Variables of the Create Inventory Script should be shown

		CreateInventoryScript inventoryScript = (CreateInventoryScript)target;

		if(GUILayout.Button ("Create Inventory"))
		{
			inventoryScript.CreateInventory();
		}
	}
}
