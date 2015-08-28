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



	//This class saves the information of every terrain junk
	[Serializable]
	public class TerrainJunks
	{
		public int columns;
		public int rows;
		public Vector3[,] tilePosition;
		public GameObject[,] tileObject;
		public enum TerrainTypes {Standard, Mountain, Water};
		public TerrainTypes terrainType;

		//Function to initialize the class object
		public TerrainJunks(int columnNr, int rowNr)
		{
			tilePosition = new Vector3[columnNr,rowNr];
			tileObject = new GameObject[columnNr,rowNr];
			int terrainTypeId = RandomTerrain();
			switch(terrainTypeId)
			{
				case 0:terrainType = TerrainTypes.Standard;break;
				case 1:terrainType = TerrainTypes.Mountain;break;
				case 2:terrainType = TerrainTypes.Water;break;
				default:terrainType = TerrainTypes.Standard;break;
			}
			Debug.Log (terrainType);
		}

		//Set a random terrain type and save it to the variable
		public int RandomTerrain ()
		{
			//int enumSize = terrainType.GetNames(typeof(TerrainTypes)).Length;
			int enumSize = 3;
			int randomNumber = Random.Range(0, enumSize);

			return randomNumber;
		}
	}

	public int columns = 20; //Columns for each terrain Junk
	public int rows = 20; //Rows for each terrain Junk
	private int startPositionX;
	private int startPositionY;
	public GameObject[] dirtTiles;
	public GameObject[] airTiles;

	public GameObject terrainContainer;
	private Transform tileHolder;

	private List<TerrainJunks> terrainList = new List<TerrainJunks>();

	//SetUp the next terrainJunk
	void SetUpTerrainJunk()
	{
		TerrainJunks terrainObject = new TerrainJunks(columns, rows);
		InitializePositionArray(ref terrainObject);
		//TerrainSetup();
	}


	//Initialize a list of possible positions
	void InitializePositionArray(ref TerrainJunks recievedTerrainObject)
	{

		startPositionX = 0;
		startPositionY = 0;

		for ( int x = -startPositionX; x < columns; x++)
		{
			for ( int y = -startPositionY; y < rows; y++)
			{
				recievedTerrainObject.tilePosition[x,y] = new Vector3(x,y,0);
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

		SetUpTerrainJunk();
	}

}
