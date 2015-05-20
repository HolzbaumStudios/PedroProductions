using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(CreateInventoryScript))]
public class CreateInventoryEditor : Editor
{
	public override void OnInspectorGUI()
	{
		//DrawDefaultInspector(); //Use this if the Variables of the Create Inventory Script should be shown

		CreateInventoryScript inventoryScript = (CreateInventoryScript)target;


		//Inventory Creation Values

		inventoryScript.columns = EditorGUILayout.IntSlider("Columns", inventoryScript.columns, 1, 10 );
		inventoryScript.rows = EditorGUILayout.IntSlider("Rows", inventoryScript.rows, 1, 30 );
		inventoryScript.slotSize = EditorGUILayout.IntSlider("Slot Size", inventoryScript.slotSize, 10, 150 );
		inventoryScript.iconSize = EditorGUILayout.IntSlider("Icon Size", inventoryScript.iconSize, 10, 150 );


		bool showDesignOptions = false;
		showDesignOptions = EditorGUILayout.Foldout(showDesignOptions, "Design Elements");
		if(showDesignOptions)
		{
			EditorGUILayout.IntSlider("Columns", inventoryScript.columns, 1, 10 );
		}


		if(GUILayout.Button ("Create Inventory"))
		{
			inventoryScript.CreateInventory();
		}
	}
}
