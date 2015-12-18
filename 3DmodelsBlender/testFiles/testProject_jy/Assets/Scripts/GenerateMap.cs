using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateMap : MonoBehaviour {

	public static GameObject plane;

	public LayerMask unwalkableMask;
	//public LayerMask roadMask;
	Node[,] Map;
	public Vector2 gridWorldSize;

	GameObject thisBuilding;

	public float nodeRadius;
	float nodeDiameter;
	int gridSizeX, gridSizeY;

	int scale;
	public int numBuildings;
	public int numPrefabs;
	public List<Vector3> positions = new List<Vector3> ();
	public List<GameObject> buildingPrefabs = new List<GameObject>();

	static GenerateRoads roadbuilder;

	void Awake(){
		plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
		scale = (int)gridWorldSize.x/10; // scaling the plane gives an 10*scale x 10*scale (x-axis x z-axis) plane, set to 50
		plane.transform.localScale = new Vector3 (scale, 1, scale); //scales only in x and z dimensions

		roadbuilder = GetComponent<GenerateRoads>();
		roadbuilder.Generate ();
	}
	// Use this for initialization
	void Start () {
		//GameObject building1 = Resources.Load("Buildings/building1") as GameObject;
		//GameObject building2 = (GameObject)Resources.Load ("Buildings/building2");
		//GameObject building3 = (GameObject)Resources.Load ("Buildings/building3");

		nodeDiameter = nodeRadius*2;
		gridSizeX = Mathf.RoundToInt(gridWorldSize.x/nodeDiameter);
		gridSizeY = Mathf.RoundToInt(gridWorldSize.y/nodeDiameter);
	
		Generate();
	
	}

	//int i = 0;

	void Generate(){

		for(int i =0; i<numBuildings; i++){
			//while(i < numBuildings){

				CreateGrid();
				List<Node> unwalkables = getUnwalkables();
				thisBuilding =(GameObject)InstantiatePrefab(); 
				CreateGrid();
				List<Node> unwalkables2 = getUnwalkables(thisBuilding);
				

					foreach(Node n in unwalkables){

						//Debug.Log(n.worldPosition);
						bool breaking = false;
						foreach(Node m in unwalkables2){
						if(n.worldPosition==m.worldPosition){
						DestroyImmediate(thisBuilding);
						
						breaking = true;
						break;
						
						}
						if(breaking)
						break;
					}
					
				}
		}
	}


	Object InstantiatePrefab() {
		int number = Random.Range (0, numPrefabs);
		Vector3 position = new Vector3 (Random.Range (-scale*5, scale*5), 0, Random.Range (-scale*5, scale*5)); //random position in the x,z-plane
		positions.Add (position);
		position.y = buildingPrefabs [number].transform.position.y; //make sure they spawn on top of the plane instead of y=0 w.r.t. their pivot point
		
		Object building;
		if (number != 2) {
			building = Instantiate (buildingPrefabs [number], position, Quaternion.Euler (-90f, 0f, 0f));
		} else {
			building = Instantiate (buildingPrefabs [number], position, Quaternion.identity);
		}
		return building;
	}
	
	void CreateGrid(){

		Map = new Node[gridSizeX, gridSizeY];
		Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x/2 - Vector3.forward * gridWorldSize.y/2;

		for(int x=0; x<gridSizeX; x++){
			for(int y=0; y<gridSizeX; y++){
				Vector3 worldPoint = worldBottomLeft + Vector3.right * (x*nodeDiameter + nodeRadius) + Vector3.forward * (y*nodeDiameter+ nodeRadius);
				
				bool walkable = !(Physics.CheckSphere(worldPoint, nodeRadius, unwalkableMask));
//				if(walkable){
//					walkable = !(Physics.CheckSphere(worldPoint, nodeRadius, roadMask));
//				}
				Map[x,y] = new Node(walkable, worldPoint, x, y);
			}
		}

	}


	void OnDrawGizmos()
	{
		Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, 1, gridWorldSize.y));

		if (Map != null)
		{
			
			foreach (Node n in Map)
			{
				Gizmos.color = (n.walkable)?Color.white:Color.red;
				
				Gizmos.DrawCube(n.worldPosition, new Vector3(nodeDiameter-.1f, nodeDiameter*0.5f, nodeDiameter-.1f));

			}
		}
	}

	List<Node> getUnwalkables(){
		List<Node> unwalk = new List<Node>();
		foreach(Node n in Map){
			if(!n.walkable)
			unwalk.Add(n);
		}
		return unwalk;
	}

	List<Node> getUnwalkables(GameObject obj){
		List<Node> unwalk = new List<Node>();
	

		int borderWidth = 8; //x-dir
		int borderHeight = 7; //z-dir

		float RightBorder = obj.transform.position.x+nodeRadius+borderWidth*nodeDiameter;
		float LeftBorder = obj.transform.position.x-nodeRadius-borderWidth*nodeDiameter;
		float TopBorder = obj.transform.position.z+nodeRadius+borderHeight*nodeDiameter;
		float DownBorder = obj.transform.position.z-nodeRadius-borderHeight*nodeDiameter;


		foreach(Node n in Map){
					if(n.worldPosition.x<RightBorder && n.worldPosition.x>LeftBorder 
						&& n.worldPosition.z>DownBorder && n.worldPosition.z<TopBorder)
					unwalk.Add(n);
		}
		return unwalk;
	}

}
