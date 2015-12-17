using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateRoads : MonoBehaviour {
	GameObject plane;
	float planeSize;
	public static GameObject road;
	static Vector3 roadSize;
	Vector3 startpos;
	public List<Vector3> positionsLog = new List<Vector3> ();
	public List<Vector3> spawnLog = new List<Vector3> ();
	List<int> directionsLog = new List<int>();
	float coverage = 0.4f; //the amount of coverage of roadtiles at least needed on the plane
	int numRoads;

	public bool iFaceNorth;
	public bool iFaceRight;
	public bool iFaceLeft;
	public bool iFaceBack;

	public int checkNeighborDistance;

	 void Initialize()
	{	
		plane = CreateMap.plane;
		planeSize = plane.transform.localScale.x * 10; //plane is 10*scale by 10*scale
		Debug.Log ("planeSize: " + planeSize);
		road = Resources.Load ("road") as GameObject;
		roadSize = road.GetComponent<Renderer> ().bounds.size; //gets the size of the road tile using its renderer, should be (4, 0.2, 4)
		//numRoads = 10;
		numRoads = (int) Mathf.Ceil(coverage * Mathf.Pow(planeSize / roadSize.x, 2)); 
		Debug.Log (numRoads);
		iFaceBack = false;
		iFaceLeft = false;
		iFaceRight = false;
		iFaceNorth = true;

		checkNeighborDistance = 3; //aanpassen bij het testen
	}

	public void createRoads () {
		Initialize ();
		
		startpos = new Vector3 (0f, 0f, 0f);        

		int startSide = Random.Range (0, 4);
		Debug.Log ("startside: " + startSide);

		switch(startSide){
		case 0: //south
			startpos.x = Random.Range ((float)(-planeSize/2), (float)(planeSize/2));
			startpos.z = -planeSize/2;
			break;
		case 1: //east
			startpos.x = planeSize/2;
			startpos.z = Random.Range ((float)(-planeSize/2), (float)(planeSize/2));
			break;
		case 2: //north
			startpos.x = Random.Range ((float)(-planeSize/2), (float)(planeSize/2));
			startpos.z = planeSize/2;
			break;
		case 3:
			startpos.x = -planeSize/2;
			startpos.z = Random.Range ((float)(-planeSize/2), (float)(planeSize/2));
			break;
		}

		//first tile
		//startpos = new Vector3 (Random.Range ((float)(-planeSize/2), (float)(planeSize/2)), 0f, Random.Range ((float)(-planeSize/2), (float)(planeSize/2)));
		Instantiate (road, startpos, Quaternion.identity);
		positionsLog.Add (startpos);
		directionsLog.Add(0);
		Debug.Log ("initpos: " + startpos);


		//create the rest
		for (int i =1; i<= numRoads; i++) {
			SetNextRoadTile();
			Vector3 lastposition = positionsLog[positionsLog.Count -1];
			Debug.Log("lastpos: " +lastposition);
		}

	}

	void SetNextRoadTile() {
		Vector3 lastPos = positionsLog [positionsLog.Count - 1];
		Debug.Log ("lastpos: " + lastPos);
		Vector3 spawnpos;

		//int direction = chooseDirection (lastPos);
		int direction = chooseDirection ();
		switch(direction){
		case 0:
			spawnpos = lastPos + new Vector3(0f, 0f , roadSize.z);

			//within boundaries
			if ((spawnpos.x<= planeSize /2 - roadSize.x/2 && spawnpos.x >= -(planeSize /2 - roadSize.x/2)) && (spawnpos.z <= planeSize /2 - roadSize.z/2 && spawnpos.z >= -(planeSize /2 - roadSize.z/2))) {
			//make sure there is no left or right neighbor in this empty space
				if (!spawnLog.Contains(spawnpos) && !spawnLog.Contains (new Vector3 (spawnpos.x + roadSize.x, spawnpos.y, spawnpos.z)) && !spawnLog.Contains (new Vector3 (spawnpos.x - roadSize.x, spawnpos.y, spawnpos.z))) {
					directionsLog.Add(direction);
					positionsLog.Add(spawnpos);
					Instantiate (road, spawnpos, Quaternion.identity);
					spawnLog.Add(spawnpos);
				}
				//there is already a tile here
				else if (spawnLog.Contains(spawnpos)) {
					directionsLog.Add(direction);
					positionsLog.Add(spawnpos);
					SetNextRoadTile();
				}
				//this spawnposition is not valid
				else {
					SetNextRoadTile();
				}
			}
			//this spawnposition is not valid
			else {
				SetNextRoadTile();
			}
			break;
		case 1:
			spawnpos = lastPos + new Vector3(roadSize.x, 0f, 0f);

			//within boundaries
			if ((spawnpos.x<= planeSize /2 - roadSize.x/2 && spawnpos.x >= -(planeSize /2 - roadSize.x/2)) && (spawnpos.z <= planeSize /2 - roadSize.z/2 && spawnpos.z >= -(planeSize /2 - roadSize.z/2))) {
				//make sure there is no upperneighbor or downneighbor in this empty space
				if (!spawnLog.Contains(spawnpos) && !spawnLog.Contains (new Vector3 (spawnpos.x, spawnpos.y, spawnpos.z + roadSize.z)) && !spawnLog.Contains (new Vector3 (spawnpos.x, spawnpos.y, spawnpos.z - roadSize.z))) {
					directionsLog.Add(direction);
					positionsLog.Add (spawnpos); 
					Instantiate (road, spawnpos, Quaternion.identity);
					spawnLog.Add(spawnpos);
				}
				//there is already a tile here
				else if (spawnLog.Contains(spawnpos)) {
					directionsLog.Add(direction);
					positionsLog.Add(spawnpos);
					SetNextRoadTile();
				}
				//this spawnposition is not valid
				else {
					SetNextRoadTile();
				}
			}
			//this spawnposition is not valid
			else {
				SetNextRoadTile();
			}
			break;
		case 2:
			spawnpos = lastPos - new Vector3(roadSize.x, 0f, 0f);

			//within boundaries
			if ((spawnpos.x<= planeSize /2 - roadSize.x/2 && spawnpos.x >= -(planeSize /2 - roadSize.x/2)) && (spawnpos.z <= planeSize /2 - roadSize.z/2 && spawnpos.z >= -(planeSize /2 - roadSize.z/2))) {
				//make sure there is no upperneighbor or downneighbor
				if (!spawnLog.Contains (new Vector3 (spawnpos.x, spawnpos.y, spawnpos.z + roadSize.z)) && !spawnLog.Contains (new Vector3 (spawnpos.x, spawnpos.y, spawnpos.z - roadSize.z))) {
					directionsLog.Add(direction);
					positionsLog.Add (spawnpos);
					Instantiate (road, spawnpos, Quaternion.identity);
					spawnLog.Add(spawnpos);
				}
				//there is already a tile here
				else if (spawnLog.Contains(spawnpos)) {
					directionsLog.Add(direction);
					positionsLog.Add(spawnpos);
					SetNextRoadTile();
				}
				//this spawnposition is not valid
				else {
					SetNextRoadTile();
				}
			}
			//this spawnposition is not valid
			else {
				SetNextRoadTile();
			}
			break;
		case 3:
			spawnpos = lastPos - new Vector3(0f, 0f , roadSize.z);

			//within boundaries
			if ((spawnpos.x<= planeSize /2 - roadSize.x/2 && spawnpos.x >= -(planeSize /2 - roadSize.x/2)) && (spawnpos.z <= planeSize /2 - roadSize.z/2 && spawnpos.z >= -(planeSize /2 - roadSize.z/2))) {
				//make sure there is no left or right neighbor in this empty space
				if (!spawnLog.Contains(spawnpos) && !spawnLog.Contains (new Vector3 (spawnpos.x + roadSize.x, spawnpos.y, spawnpos.z)) && !spawnLog.Contains (new Vector3 (spawnpos.x - roadSize.x, spawnpos.y, spawnpos.z))) {
					directionsLog.Add(direction);
					positionsLog.Add(spawnpos);
					Instantiate (road, spawnpos, Quaternion.identity);
					spawnLog.Add(spawnpos);
				}
				//there is already a tile here
				else if (spawnLog.Contains(spawnpos)) {
					directionsLog.Add(direction);
					positionsLog.Add(spawnpos);
					SetNextRoadTile();
				}
				//this spawnposition is not valid
				else {
					SetNextRoadTile();
				}
			}
			//this spawnposition is not valid
			else {
				SetNextRoadTile();
			}
			break;
		};

	}

	List<float> CalcFloats(Vector3 thispos) {
		List<float> floats = new List<float> (); //0 = forwardfloat, 1 = rightfloat-forwardfloat, 2 = leftfloat-rightfloat

		//relative to the tile
		float frontNeighbors = 0f;
		float leftNeighbors = 0f;
		float rightNeighbors = 0f;
		float backNeighbors = 0f;

		int i;

			for (i = 1; i<= checkNeighborDistance; i++) {
				//check in z-positive
				if(spawnLog.Contains(new Vector3(0f, 0f, i*roadSize.z) + thispos)){
					
					if (iFaceNorth){
					frontNeighbors+=checkNeighborDistance/i;
					}
					else if (iFaceLeft) {
					rightNeighbors+=checkNeighborDistance/i;
					}
					else if (iFaceRight) {
					leftNeighbors+=checkNeighborDistance/i;
					}
					else {
					backNeighbors+=checkNeighborDistance/i;
					}
				}
				else if (spawnLog.Contains(new Vector3(-roadSize.x, 0f, i*roadSize.z) + thispos)) {
					if (iFaceNorth){
						frontNeighbors+=checkNeighborDistance/i;
					}
					else if (iFaceLeft) {
						rightNeighbors+=checkNeighborDistance/i;
					}
					else if (iFaceRight) {
						leftNeighbors+=checkNeighborDistance/i;
					}
					else {
						backNeighbors+=checkNeighborDistance/i;
					}
				}
				else if(spawnLog.Contains(new Vector3(roadSize.x, 0f, i*roadSize.z) + thispos)){
					if (iFaceNorth){
						frontNeighbors+=checkNeighborDistance/i;
					}
					else if (iFaceLeft) {
						rightNeighbors+=checkNeighborDistance/i;
					}
					else if (iFaceRight) {
						leftNeighbors+=checkNeighborDistance/i;
					}
					else {
						backNeighbors+=checkNeighborDistance/i;
					}
				}
				//check x-positive
			else if (spawnLog.Contains(new Vector3(i*roadSize.x, 0f, 0f) + thispos)){
				if (iFaceNorth){
					rightNeighbors+=checkNeighborDistance/i;
				}
				else if (iFaceLeft) {
					backNeighbors+=checkNeighborDistance/i;
				}
				else if (iFaceRight) {
					frontNeighbors+=checkNeighborDistance/i;
				}
				else {
					leftNeighbors+=checkNeighborDistance/i;
				}
			}
			else if (spawnLog.Contains(new Vector3(i*roadSize.x, 0f, roadSize.z) + thispos)){
				if (iFaceNorth){
					rightNeighbors+=checkNeighborDistance/i;
				}
				else if (iFaceLeft) {
					backNeighbors+=checkNeighborDistance/i;
				}
				else if (iFaceRight) {
					frontNeighbors+=checkNeighborDistance/i;
				}
				else {
					leftNeighbors+=checkNeighborDistance/i;
				}
			}
			else if (spawnLog.Contains(new Vector3(i*roadSize.x, 0f, -roadSize.z) + thispos)){
				if (iFaceNorth){
					rightNeighbors+=checkNeighborDistance/i;
				}
				else if (iFaceLeft) {
					backNeighbors+=checkNeighborDistance/i;
				}
				else if (iFaceRight) {
					frontNeighbors+=checkNeighborDistance/i;
				}
				else {
					leftNeighbors+=checkNeighborDistance/i;
				}
			}
				//check x-negative
				else if (spawnLog.Contains(new Vector3(-i*roadSize.x, 0f, 0f) + thispos)){
				if (iFaceNorth){
					leftNeighbors+=checkNeighborDistance/i;
				}
				else if (iFaceLeft) {
					frontNeighbors+=checkNeighborDistance/i;
				}
				else if (iFaceRight) {
					backNeighbors+=checkNeighborDistance/i;
				}
				else {
					rightNeighbors+=checkNeighborDistance/i;
				}
			}
			else if (spawnLog.Contains(new Vector3(-i*roadSize.x, 0f, roadSize.z) + thispos)){
				if (iFaceNorth){
					leftNeighbors+=checkNeighborDistance/i;
				}
				else if (iFaceLeft) {
					frontNeighbors+=checkNeighborDistance/i;
				}
				else if (iFaceRight) {
					backNeighbors+=checkNeighborDistance/i;
				}
				else {
					rightNeighbors+=checkNeighborDistance/i;
				}
			}
			else if (spawnLog.Contains(new Vector3(-i*roadSize.x, 0f, -roadSize.z) + thispos)){
				if (iFaceNorth){
					leftNeighbors+=checkNeighborDistance/i;
				}
				else if (iFaceLeft) {
					frontNeighbors+=checkNeighborDistance/i;
				}
				else if (iFaceRight) {
					backNeighbors+=checkNeighborDistance/i;
				}
				else {
					rightNeighbors+=checkNeighborDistance/i;
				}
			}

				//check z-negative
			if(spawnLog.Contains(new Vector3(0f, 0f, -i*roadSize.z) + thispos)){
				
				if (iFaceNorth){
					backNeighbors+=checkNeighborDistance/i;
				}
				else if (iFaceLeft) {
					leftNeighbors+=checkNeighborDistance/i;
				}
				else if (iFaceRight) {
					rightNeighbors+=checkNeighborDistance/i;
				}
				else {
					frontNeighbors+=checkNeighborDistance/i;
				}
			}
			else if (spawnLog.Contains(new Vector3(-roadSize.x, 0f, -i*roadSize.z) + thispos)) {
				if (iFaceNorth){
					backNeighbors+=checkNeighborDistance/i;
				}
				else if (iFaceLeft) {
					leftNeighbors+=checkNeighborDistance/i;
				}
				else if (iFaceRight) {
					rightNeighbors+=checkNeighborDistance/i;
				}
				else {
					frontNeighbors+=checkNeighborDistance/i;
				}
			}
			else if(spawnLog.Contains(new Vector3(roadSize.x, 0f, -i*roadSize.z) + thispos)){
				if (iFaceNorth){
					backNeighbors+=checkNeighborDistance/i;
				}
				else if (iFaceLeft) {
					leftNeighbors+=checkNeighborDistance/i;
				}
				else if (iFaceRight) {
					rightNeighbors+=checkNeighborDistance/i;
				}
				else {
					frontNeighbors+=checkNeighborDistance/i;
				}
			}
		}

		float totalNeighbors = frontNeighbors + rightNeighbors + leftNeighbors + backNeighbors;
		Debug.Log ("front: " + frontNeighbors + "right: " + rightNeighbors + "left: " + leftNeighbors + "back: " + frontNeighbors);

		floats.Add(1-frontNeighbors/totalNeighbors);
		floats.Add (1 - floats [0] - rightNeighbors / totalNeighbors);
		floats.Add (1 - floats [0] - floats [1] - leftNeighbors / totalNeighbors);

		return floats;
	}

	//int chooseDirection(Vector3 thispos) {
		int chooseDirection() {
		int direction;

		//List<float> floats = CalcFloats (thispos);

		//relative directions
//		float forward = floats[0];
//		float right = floats[0] + floats[1];
//		float left = floats[1] + floats[2];

				float forward = 0.6f;
				float right = 0.7f;
				float left = 0.8f;

		float rndFloat = Random.value;

		//relative directions
		if (iFaceNorth) {
			if (rndFloat < forward) {
				iFaceBack = false;
				iFaceLeft = false;
				iFaceNorth = true;
				iFaceRight = false;
				return direction = 0; //forward
			} else if (rndFloat >= forward && rndFloat < right) {
				iFaceBack = false;
				iFaceLeft = false;
				iFaceNorth = false;
				iFaceRight = true;
				return direction = 1; //right
			} else if (rndFloat >= right && rndFloat < left ){
				iFaceBack = false;
				iFaceLeft = true;
				iFaceNorth = false;
				iFaceRight = false;
				return direction = 2; //left
			} else {
				iFaceBack = true;
				iFaceLeft = false;
				iFaceNorth = false;
				iFaceRight = false;
				return direction = 3; //backward
			}
		}
		else if(iFaceBack) {
			if (rndFloat < forward) {
				iFaceBack = true;
				iFaceLeft = false;
				iFaceNorth = false;
				iFaceRight = false;
				return direction = 3; //forward
			} else if (rndFloat >= forward && rndFloat < right) {
				iFaceBack = false;
				iFaceLeft = true;
				iFaceNorth = false;
				iFaceRight = false;
				return direction = 2; //right
			} else if (rndFloat >= right && rndFloat < left) {
				iFaceBack = false;
				iFaceLeft = false;
				iFaceNorth = false;
				iFaceRight = true;
				return direction = 1; //left
			} else {
				iFaceBack = false;
				iFaceLeft = false;
				iFaceNorth = true;
				iFaceRight = false;
				return direction = 0; //backward
			}

		}
		else if (iFaceRight) {
			if (rndFloat < forward) {
					iFaceBack = false;
					iFaceLeft = false;
					iFaceNorth = false;
					iFaceRight = true;
				return direction = 1; //forward
			} else if (rndFloat >= forward && rndFloat < right) {
					iFaceBack = true;
					iFaceLeft = false;
					iFaceNorth = false;
					iFaceRight = false;
				return direction = 3; //right
			} else if (rndFloat >= right && rndFloat < left) {
					iFaceBack = false;
					iFaceLeft = false;
					iFaceNorth = true;
					iFaceRight = false;
				return direction = 0; //left
			} else {
					iFaceBack = false;
					iFaceLeft = true;
					iFaceNorth = false;
					iFaceRight = false;
				return direction = 2; //backward
			}

		}
		else {
			if (rndFloat < forward) {
						iFaceBack = false;
						iFaceLeft = true;
						iFaceNorth = false;
						iFaceRight = false;
				return direction = 2; //forward
			} else if (rndFloat >= forward && rndFloat < right) {
						iFaceBack = false;
						iFaceLeft = false;
						iFaceNorth = true;
						iFaceRight = false;
				return direction = 0; //right
			} else if (rndFloat >= right && rndFloat < left) {
						iFaceBack = true;
						iFaceLeft = false;
						iFaceNorth = false;
						iFaceRight = false;
				return direction = 3; //left
			} else {
						iFaceBack = false;
						iFaceLeft = false;
						iFaceNorth = false;
						iFaceRight = true;
				return direction =1; //backward
			}
			
		}

	}
}