using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//this script is temporary and does not create roads
//attached to an empty object

public class buildLevel : MonoBehaviour {
	int scale;
	int numBuildings;
	int i;

	public List<Vector3> positions = new List<Vector3> ();
	public int numPrefabs;
	public List<GameObject> buildingPrefabs = new List<GameObject>();
	public List<Object> instantiatedBuildings = new List<Object>();

	void Start () {
		GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
		scale = 10; // scaling the plane
		plane.transform.localScale = new Vector3 (scale, 1, scale); //scales only in x and z dimensions

		GameObject building1 = Resources.Load("Buildings/building1") as GameObject;
		GameObject building2 = (GameObject)Resources.Load ("Buildings/building2");
		GameObject building3 = (GameObject)Resources.Load ("Buildings/ohiov2");
		buildingPrefabs.Add (building1); //+90 degrees in x-axis
		buildingPrefabs.Add (building2); //+90 degrees in x-axis	
		buildingPrefabs.Add (building3); //normal

		numPrefabs = buildingPrefabs.Count;
		numBuildings = 20;

		for (i =1; i < numBuildings; i++) {
			int number = Random.Range (0, numPrefabs);
			//Invoke("InstantiatePrefab", 2f);
			InstantiatePrefab(number);
			Debug.Log (number);
		}
	}

	void InstantiatePrefab(int number) {
		Vector3 position = new Vector3 (Random.Range (-scale, scale), 0, Random.Range (-scale, scale)); //random position in the x,z-plane
		//if (positions.Find(Vector3 => Vector3.Equals(position)) == null) { //cannot use contains as the reference (memorypointer) of position is unique everytime a new vertor3 is made
		positions.Add (position);
		Object building;
		if (number != 2) {
			building = Instantiate (buildingPrefabs [number], position, Quaternion.Euler (-90f, 0f, 0f));
		} else {
			building = Instantiate (buildingPrefabs [number], position, Quaternion.identity);
		}
		instantiatedBuildings.Add (building);
			//Instantiate (buildingPrefabs [Random.Range (0, numPrefabs)], position, Quaternion.identity);
		}

		//else {
		//	i--;
		//	return;
		//}
	//}
	
}

