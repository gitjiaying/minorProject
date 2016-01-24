using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GenerateRoads : MonoBehaviour {
	GameObject plane;
	GameObject terrain;
	Vector2 planeSize;
	GameObject tree;

	public static GameObject road;
	static Vector3 roadSize;

	float upperborder;
	float rightborder;

	public List<Vector3> spawnlog; 
	public List<int> directionslog;
	public List<Vector3> lastSpawned;

	public List<Vector3> treeSpawnlog;
	float treeSpawnOffsetx ;
	float treeSpawnOffsetz ;

	List<Vector3> tempSpawn;
	List<Vector3> tempTreeSpawn;

	int[] spawnRotations = new int[] {0, 90, 180, 270};


	void Initialize () {

		plane = GenerateMap.plane;
		planeSize.x = plane.transform.localScale.x * 10; //plane is 10*scale by 10*scale
		planeSize.y = plane.transform.localScale.z* 10; //plane is 10*scale by 10*scale

		//roadTile spawnpoint is the center of the tile
		road = Resources.Load ("Ground/road2") as GameObject;
		roadSize = road.GetComponent<Renderer> ().bounds.size; //gets the size of the road tile using its renderer

		upperborder = planeSize.y/2 - roadSize.z/2; //z-value border relative to a roadtile
		rightborder = planeSize.x/2 - roadSize.x/2; //x-value relative to a roadtile
		spawnlog = new List<Vector3> ();
		directionslog = new List<int> ();
		lastSpawned = new List<Vector3> ();
		
		tree = (GameObject)Resources.Load ("Trees/TreeWithBorder");
		treeSpawnOffsetx = roadSize.x;
		treeSpawnOffsetz = roadSize.z;
		treeSpawnlog = new List<Vector3> ();
		CreateFirstTiles ();
	}


	void AddTreeSpawnPositions(Vector3 spawnpos, int toss) {
		if (toss == 0 || toss == 1) { //vertical spawning
			Vector3 spawn1 = spawnpos + new Vector3 (treeSpawnOffsetx, 0, 0);
			treeSpawnlog.Add (spawn1);
			Vector3 spawn2 = spawnpos + new Vector3 (-treeSpawnOffsetx, 0, 0);
			treeSpawnlog.Add (spawn2);
		} else {
			Vector3 spawn1 = spawnpos + new Vector3 (0, 0, treeSpawnOffsetz);
			treeSpawnlog.Add (spawn1);
			Vector3 spawn2 = spawnpos + new Vector3 (0, 0, -treeSpawnOffsetz);
			treeSpawnlog.Add (spawn2);
		}

	}

	void CreateFirstTiles() {
		int tossUOD = Random.Range (0, 2); //0 = down, 1=up
		int tossROL = Random.Range (2, 4); //2 = right, 3 = left
		Debug.Log ("UOD: " + tossUOD + " ROL: " + tossROL);

		int s = 4;

		Vector3 startpos = new Vector3 (Random.Range (-rightborder/s, rightborder/s), 0f, Random.Range (-upperborder/s, upperborder/s));

		// one main vertical road, top to bottom
		for (float i = startpos.z; i <= upperborder; i= i+roadSize.z) {
							Vector3 spawnpos = new Vector3 (startpos.x, 0f, i);
							//Instantiate (road, spawnpos, Quaternion.identity);
							spawnlog.Add (spawnpos);
							AddTreeSpawnPositions(spawnpos, tossUOD);
						}

			for (float i = startpos.z; i >= -upperborder; i= i-roadSize.z) {
								Vector3 spawnpos = new Vector3 (startpos.x, 0f, i);
								//Instantiate (road, spawnpos, Quaternion.identity);
								spawnlog.Add (spawnpos);
								AddTreeSpawnPositions(spawnpos, tossUOD);
							}
		//one horizontal road crossing the vertivcal one
		for (float i = startpos.z; i >= -upperborder; i= i-roadSize.z) {
							Vector3 spawnpos = new Vector3 (startpos.x, 0f, i);
							//Instantiate (road, spawnpos, Quaternion.identity);
							spawnlog.Add (spawnpos);
							AddTreeSpawnPositions(spawnpos, tossUOD);
						}

			for (float i = startpos.x; i >= -rightborder; i= i-roadSize.x) {
								Vector3 spawnpos = new Vector3 (i, 0f, startpos.z);
								//Instantiate (road, spawnpos, Quaternion.identity);
								spawnlog.Add (spawnpos);
								lastSpawned.Add(spawnpos);
								AddTreeSpawnPositions(spawnpos, tossROL);
							}

		directionslog.Add (tossUOD);
		directionslog.Add (tossROL);

	}

	void CreateNext() {
		int lastdir = directionslog [directionslog.Count - 1];

		int startindex = Mathf.FloorToInt ((float)0.2 * lastSpawned.Count);
		int index = Random.Range (startindex, lastSpawned.Count-1); 
		Vector3 startpos = lastSpawned [index];
		Debug.Log ("spawnposition: " + startpos);

		int toss;

		lastSpawned = new List<Vector3> (); //empty lastspawned
		if (lastdir == 0 || lastdir == 1) {
			toss = Random.Range (2, 4);
			directionslog.Add(toss);
			if (toss == 2) {
				for (float i = startpos.x; i <= rightborder; i= i+roadSize.x) {
					Vector3 spawnpos = new Vector3 (i, 0f, startpos.z);
					//Instantiate (road, spawnpos, Quaternion.identity);
					spawnlog.Add (spawnpos);
					lastSpawned.Add (spawnpos);
					AddTreeSpawnPositions(spawnpos, toss);
				}
			} else {
				for (float i = startpos.x; i >= -rightborder; i= i-roadSize.x) {
					Vector3 spawnpos = new Vector3 (i, 0f, startpos.z);
					//Instantiate (road, spawnpos, Quaternion.identity);
					spawnlog.Add (spawnpos);
					lastSpawned.Add (spawnpos);
					AddTreeSpawnPositions(spawnpos, toss);
				}
			}

		} else {
			toss=Random.Range (0,2);
			directionslog.Add(toss);

			if (toss == 1) {
				for (float i = startpos.z; i <= upperborder; i= i+roadSize.z) {
					Vector3 spawnpos = new Vector3 (startpos.x, 0f, i);
					//Instantiate (road, spawnpos, Quaternion.identity);
					spawnlog.Add (spawnpos);
					lastSpawned.Add(spawnpos);
					AddTreeSpawnPositions(spawnpos, toss);
				}
			} else {
				for (float i = startpos.z; i >= -upperborder; i= i-roadSize.z) {
					Vector3 spawnpos = new Vector3 (startpos.x, 0f, i);
					//Instantiate (road, spawnpos, Quaternion.identity);
					spawnlog.Add (spawnpos);
					lastSpawned.Add(spawnpos);
					AddTreeSpawnPositions(spawnpos, toss);
				}
			}
		}


	}
	

	public void Generate() {
			Initialize ();

			int iter = 5; //number of iterations
		for (int i=1; i<=iter; i++) {
			CreateNext ();
		}

		//checking for overlaps in roads
		spawnlog = getUnique (spawnlog);
		for (int i =0; i<spawnlog.Count; i++) {
			Instantiate(road, spawnlog[i], Quaternion.identity);
		}

		//checking and instantiating trees against roads
		treeSpawnlog = getUnique (treeSpawnlog);
		tempSpawn = RoundedPositions (spawnlog);
		tempTreeSpawn = RoundedPositions (treeSpawnlog);
		CheckRoadVSTree ();
		for (int j = 0; j< treeSpawnlog.Count-1; j=j+4) {
			float randomScale;
			int rotationIndex = Random.Range (0, spawnRotations.Length);
			GameObject tree1 = (GameObject) Instantiate(tree, treeSpawnlog[j] + new Vector3(0, tree.transform.position.y, 0), Quaternion.Euler(0f, (float) spawnRotations[rotationIndex], 0f));
			randomScale = Random.Range (tree.transform.localScale.y, tree.transform.localScale.y + 0.5f);
			tree1.transform.localScale = new Vector3(1f, randomScale, 1f);

			int tree1X = Mathf.RoundToInt(treeSpawnlog[j].x);
			int tree1Z = Mathf.RoundToInt(treeSpawnlog[j].z);
			if(tree1X%2==0){
				tree1X+=1;}
			if (tree1Z%2==0){
				tree1Z +=1;
			}
			tree1.transform.localPosition = new Vector3(tree1X, tree.transform.position.y*Mathf.Sqrt(Mathf.Sqrt(randomScale)), tree1Z);

			rotationIndex = Random.Range (0, spawnRotations.Length);
			GameObject tree2 = (GameObject) Instantiate(tree, treeSpawnlog[j+1] + new Vector3(0, tree.transform.position.y, 0), Quaternion.Euler(0f, (float) spawnRotations[rotationIndex], 0f));
			randomScale = Random.Range (tree.transform.localScale.y, tree.transform.localScale.y + 0.5f);
			tree2.transform.localScale = new Vector3(1f, randomScale, 1f);

			int tree2X = Mathf.RoundToInt(treeSpawnlog[j+1].x);
			int tree2Z = Mathf.RoundToInt(treeSpawnlog[j+1].z);
			if(tree2X%2==0){
				tree2X+=1;}
			if (tree2Z%2==0){
				tree2Z +=1;
			}
			tree2.transform.localPosition = new Vector3(tree2X, tree.transform.position.y*Mathf.Sqrt(Mathf.Sqrt(randomScale)), tree2Z);


		}

	}

	List<Vector3> getUnique(List<Vector3> set) {
		List<Vector3> ok = new List<Vector3> ();

		for (int i = 0; i < set.Count; i++) {
			if (!ok.Contains (set [i])) {
				ok.Add (set [i]);
			}
		}
		return ok;
	}

	//rounds the x and z coordinates to integers
	List<Vector3> RoundedPositions(List<Vector3> positions) {
		List<Vector3> res = new List<Vector3> ();

		for (int i =0; i<positions.Count; i++) {
			res.Add(new Vector3(Mathf.CeilToInt (positions[i].x), 0, Mathf.CeilToInt (positions[i].z)));
		}

		return res;
	}

	//deletes trees overlapping roads
	void CheckRoadVSTree() {
		for (int i= 0; i< tempTreeSpawn.Count; i++) {
			if (tempSpawn.Contains(tempTreeSpawn[i])) {
				tempTreeSpawn.RemoveAt(i);
				treeSpawnlog.RemoveAt(i);
				CheckRoadVSTree();
			}
		}

	}

}
