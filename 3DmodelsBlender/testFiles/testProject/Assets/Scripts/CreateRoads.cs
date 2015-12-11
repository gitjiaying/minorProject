using UnityEngine;
using System.Collections;

public class CreateRoads : MonoBehaviour {

	Vector2 borderX, borderZ;

	static Grid grid;
	public static Object road;

	void Awake()
	{
		grid = GetComponent<Grid> ();
		road = Resources.Load ("road") as GameObject;
		borderX = new Vector2 (grid.worldBottomLeft.x, grid.worldBottomLeft.x + grid.gridWorldSize.x); //left and right border
		borderZ = new Vector2 (grid.worldBottomLeft.z, grid.worldBottomLeft.z + grid.gridWorldSize.y); //upper and down border
	}

	public static void createRoads () {
		//int startSide = Random.Range (0, 4);
		Vector3 startpos=new Vector3(Random.Range((float)grid.worldBottomLeft.x, (float)(grid.worldBottomLeft.x + grid.gridWorldSize.x)), 0f, 
		                             Random.Range((float)grid.worldBottomLeft.z, (float)(grid.worldBottomLeft.z + grid.gridWorldSize.y)));           


//		switch(startSide){
//		case 0:
//			startpos.x = Random.Range (grid.worldBottomLeft.x, grid.worldBottomLeft.x + grid.gridWorldSize.x);
//			startpos.y = grid.worldBottomLeft.y;
//			break;
//		case 1:
//			startpos.x = grid.worldBottomLeft.z + grid.gridWorldSize.y;
//			startpos.y = Random.Range (grid.worldBottomLeft.z, grid.worldBottomLeft.z + grid.gridWorldSize.y );
//			break;
//		case 2:
//			startpos.x = Random.Range (grid.worldBottomLeft.x, grid.worldBottomLeft.x + grid.gridWorldSize.x);
//			startpos.y = grid.worldBottomLeft.z + grid.gridWorldSize.y;
//			break;
//		case 3:
//			startpos.x = grid.worldBottomLeft.x;
//			startpos.y = Random.Range(grid.worldBottomLeft.z, grid.worldBottomLeft.z + grid.gridWorldSize.y);
//			break;
//		}
		Debug.Log (startpos);

		Instantiate (road, startpos, Quaternion.identity);

	}

	void SetNextRoad() {

	}

}
