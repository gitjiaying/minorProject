using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateMap : MonoBehaviour {
	int scale;
	int numBuildings;

	public List<Vector3> positions = new List<Vector3> ();
	public int numPrefabs;
	public List<GameObject> buildingPrefabs = new List<GameObject>();
	public List<Object> instantiatedBuildings = new List<Object>();

	GameObject thisBuilding;

	public checkCollision thisCheck ;

	void Awake () {
		//CreateRoads.createRoads ();
	}

	void Start () {
		thisCheck = thisCheck.GetComponent<checkCollision>();
		GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
		scale = 10; // scaling the plane gives an 5*scale x 5*scale (x-axis x z-axis) plane, set to 50
		plane.transform.localScale = new Vector3 (scale, 1, scale); //scales only in x and z dimensions
		
		GameObject building1 = Resources.Load("Buildings/building1") as GameObject;
		GameObject building2 = (GameObject)Resources.Load ("Buildings/building2");
		GameObject building3 = (GameObject)Resources.Load ("Buildings/building3");
		buildingPrefabs.Add (building1); //+90 degrees in x-axis
		buildingPrefabs.Add (building2); //+90 degrees in x-axis	
		buildingPrefabs.Add (building3); //normal
		
		numPrefabs = buildingPrefabs.Count;
		numBuildings = 30;

		//check every instantiated building
		for (int i =1; i <= numBuildings; i++) {
			thisBuilding =(GameObject)InstantiatePrefab();
			if (thisCheck.fail){
				numBuildings++;
			}
			Debug.Log(i);
		}
	}

	Object InstantiatePrefab() {
		int number = Random.Range (0, numPrefabs);
		Vector3 position = new Vector3 (Random.Range (-scale*5, scale*5), 0, Random.Range (-scale*5, scale*5)); //random position in the x,z-plane
		positions.Add (position);
		position.y = buildingPrefabs [number].transform.position.y; //make sure they spawn on top of the plane instead of y=0 w.r.t. their pivot point
		
		Object building;
		if (number != 2) {
			return building = Instantiate (buildingPrefabs [number], position, Quaternion.Euler (-90f, 0f, 0f));
		} else {
			return building = Instantiate (buildingPrefabs [number], position, Quaternion.identity);
		}
	}


}
