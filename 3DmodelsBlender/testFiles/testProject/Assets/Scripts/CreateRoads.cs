using UnityEngine;
using System.Collections;

public class CreateRoads : MonoBehaviour {
	GameObject plane;
	public static GameObject road;
	static Vector3 roadSize;
	Vector3 startpos;

	 void Initialize()
	{	
		plane = CreateMap.plane;
		road = Resources.Load ("road") as GameObject;
		roadSize = road.GetComponent<Renderer> ().bounds.size; //gets the size of the road tile using its renderer, should be (4, 0.2, 4)
	}

	public void createRoads () {
		Initialize ();
		

		//startpos=new Vector3(Random.Range((float)grid.worldBottomLeft.x, (float)(grid.worldBottomLeft.x + grid.gridWorldSize.x)), 0f, 
		                         //    Random.Range((float)grid.worldBottomLeft.z, (float)(grid.worldBottomLeft.z + grid.gridWorldSize.y)));           

		//int startSide = Random.Range (0, 4);
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
