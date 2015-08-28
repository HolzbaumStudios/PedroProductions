using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class TerrainGenerator : MonoBehaviour {

	enum Tiles {Air, Dirt, Grass};

	[Serializable]
	public class Count
	{
		public int minimum;
		public int maximum;

		public Count (int min, int max)
		{
			minimum = min;
			maximum = max;
		}
	}

	public int columns = 20;
	public int rows = 10;
	private int startPositionX;
	private int startPositionY;
	public GameObject[] dirtTiles;
	public GameObject[] airTiles;

	public GameObject terrainContainer;
	private Transform tileHolder;


	private List <Vector3> gridPositions = new List<Vector3>();

	//Initialize a list of possible positions
	void InitializeList()
	{
		gridPositions.Clear ();

		for ( int x = -startPositionX; x < columns; x++)
		{
			for ( int y = -startPositionY; y < rows; y++)
			{
				gridPositions.Add (new Vector3(x,y,0f));
			}
		}
	}

	void TerrainSetup()
	{
		//Instantiate Board and set boardHolder to its transform.
		tileHolder = new GameObject ("TileContainer").transform;
		tileHolder.SetParent(terrainContainer.transform);


		for ( int x = -startPositionX; x < columns; x++)
		{
			for ( int y = -startPositionY; y < rows; y++)
			{
				GameObject toInstantiate = dirtTiles[Random.Range (0, dirtTiles.Length)];
				if(y > 0)
				{
					toInstantiate = airTiles[Random.Range (0, airTiles.Length)];
				}

				GameObject instance = Instantiate (toInstantiate, new Vector3 (x,y,0f), Quaternion.identity) as GameObject;
				instance.transform.SetParent(tileHolder);
			}
		}
	}
	

	// Use this for initialization
	void Start () {
		startPositionX = columns / 2;
		startPositionY = rows / 2;

		InitializeList();
		TerrainSetup ();
	}

}
