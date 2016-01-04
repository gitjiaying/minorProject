using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//this script is temporary and does not create roads
//attached to an empty object

public class BuildLevel : MonoBehaviour {
	int scale;
	int numBuildings;
	int i;
	Grid grid;

	GameObject[] allObjects;
	List<GameObject> objectsToDisable;


	public List<Vector3> positions = new List<Vector3> ();
	public int numPrefabs;
	public List<GameObject> buildingPrefabs = new List<GameObject>();
	public List<Object> instantiatedBuildings = new List<Object>();

	
	List<Node> allRed = new List<Node> (); //list all the red gridnodes from the last spawned buildings
	List<Node> currentRed = new List<Node> (); //list all the red gridnodes from this spawned building

	void Awake() {
		//CreateRoads.createRoads (); 
	} 

	void Start () {
		grid = GetComponent<Grid> (); 

		GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
		scale = 10; // scaling the plane gives an 2*5*scale x 2*5*scale (x-axis x z-axis) plane, set to 50
		plane.transform.localScale = new Vector3 (scale, 1, scale); //scales only in x and z dimensions

		GameObject building1 = Resources.Load("Buildings/building1") as GameObject;
		GameObject building2 = (GameObject)Resources.Load ("Buildings/building2");
		GameObject building3 = (GameObject)Resources.Load ("Buildings/building3");
		buildingPrefabs.Add (building1); //+90 degrees in x-axis
		buildingPrefabs.Add (building2); //+90 degrees in x-axis	
		buildingPrefabs.Add (building3); //normal
		
		numPrefabs = buildingPrefabs.Count;
		numBuildings = 50;

		//check every instantiated building
		for (i =1; i < numBuildings; i++) {
			Debug.Log(i +" " + currentRed.Count +" " + allRed.Count +" " + failCount);
			ThisStep();
			
			if (failCount == 3) {
				break;
			}
		}
	}
	
	List<Node> theseReds;
	List<Node> InstantiatePrefab() {
		allObjects = FindObjectsOfType<GameObject>();
		objectsToDisable = new List<GameObject>(allObjects);
		foreach (GameObject a in allObjects) {
			if (!a.layer.Equals("unwalkableMask") ) {
				objectsToDisable.Remove(a);
			};
		};
		foreach (GameObject b in objectsToDisable) {
			b.SetActive (false);
		}

		theseReds = new List<Node> ();
		int number = Random.Range (0, numPrefabs);
		Vector3 position = new Vector3 (Random.Range (-scale*5, scale*5), 0, Random.Range (-scale*5, scale*5)); //random position in the x,z-plane
		positions.Add (position);
		position.y = buildingPrefabs [number].transform.position.y; //make sure they spawn on top of the plane instead of y=0 w.r.t. their pivot point

		Object building;
		if (number != 2) {
			building = Instantiate (buildingPrefabs [number], position, Quaternion.Euler (-90f, 0f, 0f));
			//grid.CreateGrid();
			theseReds = grid.GetUnwalkables();
			instantiatedBuildings.Add (building); //handler for this instantiated building
			return theseReds;
		} else {
			building = Instantiate (buildingPrefabs [number], position, Quaternion.identity);
			//grid.CreateGrid();
			theseReds = grid.GetUnwalkables();
			instantiatedBuildings.Add (building); //handler for this instantiated building
			return theseReds;
		}
	}
	

	int failCount = 0;
	void ThisStep() {
		currentRed = InstantiatePrefab();
		//grid.CreateGrid(); //grid wordt elke frame geupdate
		foreach(Node n in currentRed) {
			if(allRed.Contains(n)){ //fail
				Destroy(instantiatedBuildings[instantiatedBuildings.Count -1]);
				failCount++;
				numBuildings++;
			}
			else { //succes
				failCount =0;
			}
		}
		foreach(GameObject a in objectsToDisable) {
			a.SetActive(true);
		}
		allRed = grid.GetUnwalkables();
	}

}

