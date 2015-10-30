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


		//Spacing SLider
		inventoryScript.showPivotOptions = EditorGUILayout.Foldout(inventoryScript.showPivotOptions, "Pivots");
		if(inventoryScript.showPivotOptions)
		{
			inventoryScript.pivots.topSpacing = EditorGUILayout.IntSlider("Top Spacing", inventoryScript.pivots.topSpacing, 1, 50 );
			inventoryScript.pivots.bottomSpacing = EditorGUILayout.IntSlider("Bottom Spacing", inventoryScript.pivots.bottomSpacing, 1, 50 );
			inventoryScript.pivots.leftSpacing = EditorGUILayout.IntSlider ("Left Spacing", inventoryScript.pivots.leftSpacing, 1, 50);
			inventoryScript.pivots.leftSpacing = EditorGUILayout.IntSlider ("Right Spacing", inventoryScript.pivots.rightSpacing, 1, 50);

			inventoryScript.pivots.horizontalSpacing = EditorGUILayout.IntSlider("Horizontal Spacing", inventoryScript.pivots.horizontalSpacing, 1, 50 );
			inventoryScript.pivots.verticalSpacing = EditorGUILayout.IntSlider("Vertical Spacing", inventoryScript.pivots.verticalSpacing, 1, 50 );

		}

		//Design Elements
		inventoryScript.showDesignOptions = EditorGUILayout.Foldout(inventoryScript.showDesignOptions, "Design Elements");
		if(inventoryScript.showPivotOptions)
		{
			inventoryScript.designElements.imagePrefab = EditorGUILayout.ObjectField(inventoryScript.designElements.imagePrefab, "Image Prefab");
			
		}

		if(GUILayout.Button ("Create Inventory"))
		{
			inventoryScript.CreateInventory();
		}
	}
}
