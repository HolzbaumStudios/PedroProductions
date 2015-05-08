using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(CreateInventoryScript))]
public class CreateInventoryEditor : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		CreateInventoryScript myScript = (CreateInventoryScript)target;
		if(GUILayout.Button ("Create Inventory"))
		{
			myScript.CreateInventory();
		}
	}
}
