using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//this script is temporary and does not create roads
//attached to an empty object

public class buildLevel : MonoBehaviour {
	int scale;
	int numBuildings;

	public List<GameObject> buildingPrefabs = new List<GameObject>();

	void Start () {
		GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
		scale = 10;
		plane.transform.localScale = new Vector3 (scale, 1, scale); //scales only in x and z dimensions

		GameObject building1 = Resources.Load("Buildings/building1") as GameObject;
		GameObject building2 = (GameObject)Resources.Load ("Buildings/building2");
		GameObject building3 = (GameObject)Resources.Load ("Buildings/ohiov2");
		buildingPrefabs.Add (building1);
		buildingPrefabs.Add (building2);
		buildingPrefabs.Add (building3);

		numBuildings = 10;

		for 
	}

}
