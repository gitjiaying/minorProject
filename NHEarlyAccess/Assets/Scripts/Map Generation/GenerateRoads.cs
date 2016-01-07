using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//INSTANTIATE AFTER SPAWNLOG IS DONE

public class GenerateRoads : MonoBehaviour {
//	GameObject plane;
	GameObject terrain;
	Vector2 planeSize;
	//List<Vector3> grassSpawnCoordinates = new List<Vector3> (); //wrt the grassTiles

	public static GameObject road;
	static Vector3 roadSize;
	//int sideLengthRelRoad;

	float upperborder;
	float rightborder;

	public List<Vector3> spawnlog; 
	public List<int> directionslog;
	public List<Vector3> lastSpawned;

//	public List<GameObject> grassPrefabs = new List<GameObject> ();
//	float grassTileSize = 10f;

	bool generateRoads;

	void Initialize () {
		generateRoads = true;



		planeSize = GenerateMap.groundSize;
//		for (float i = -planeSize.x/2; i< planeSize.x/2; i=i+grassTileSize) {
//			for (float j = -planeSize.y/2; j<planeSize.y/2; j+=grassTileSize) { 
//				Vector3 coordinates = new Vector3(i, 0, j);
//				grassSpawnCoordinates.Add(coordinates);
//					}
//		}
		//plane = GenerateMap.plane;
		//planeSize = plane.transform.localScale.x * 10; //plane is 10*scale by 10*scale

		//for grassTiles the rightuppercorner is the spawn point
//		GameObject grass1 = (GameObject) Resources.Load("Ground/grass1");
//		GameObject grass2 = (GameObject) Resources.Load("Ground/grass2");
//		GameObject grass3 = (GameObject) Resources.Load("Ground/grass3");
//		grassPrefabs.Add (grass1);
//		grassPrefabs.Add (grass2);
//		grassPrefabs.Add (grass3);
//
//		FillWithGrass ();

		terrain = (GameObject)Resources.Load ("Ground/grassPlane2");
		//Vector3 terrainSpawn = new Vector3 (-planeSize.x / 2, 0, -planeSize.y / 2);
		Instantiate (terrain, new Vector3(-5,0,5), Quaternion.identity);

		//for the roadtile to spawn like the grassTile, we have to correct the spawnposition of the road with +roadsize/2 per axis x and z
		//roadTile spawnpoint is the center of the tile
		road = Resources.Load ("Ground/road2") as GameObject;
		roadSize = road.GetComponent<Renderer> ().bounds.size; //gets the size of the road tile using its renderer
		//sideLengthRelRoad = (int) Mathf.Floor (planeSize / roadSize.x); //number of possible roadtiles on a side
		upperborder = planeSize.y/2 - roadSize.z/2; //z-value border relative to a roadtile
		rightborder = planeSize.x/2 - roadSize.x/2; //x-value relative to a roadtile
		spawnlog = new List<Vector3> ();
		directionslog = new List<int> ();
		lastSpawned = new List<Vector3> ();
		CreateFirstTiles ();
	}

//	void FillWithGrass() {
//		for (int i = 0; i<= grassSpawnCoordinates.Count; i++) {
//			int randomDraw = Random.Range(0, grassPrefabs.Count);
//			Instantiate (grassPrefabs[randomDraw], grassSpawnCoordinates[i], Quaternion.identity);
//		}
//	}

	void CreateFirstTiles() {
		int tossUOD = Random.Range (0, 2); //0 = down, 1=up
		int tossROL = Random.Range (2, 4); //2 = right, 3 = left
		Debug.Log ("UOD: " + tossUOD + " ROL: " + tossROL);

		int s = 4;

		Vector3 startpos = new Vector3 (Random.Range (-rightborder/s, rightborder/s), 0f, Random.Range (-upperborder/s, upperborder/s));
		Debug.Log ("startpos: " + startpos);
		if (tossUOD == 1) {
			for (float i = startpos.z; i <= upperborder; i= i+roadSize.z) {
				Vector3 spawnpos = new Vector3 (startpos.x, 0f, i);
				//Instantiate (road, spawnpos, Quaternion.identity);
				spawnlog.Add (spawnpos);
			}
		} else {
			for (float i = startpos.z; i >= -upperborder; i= i-roadSize.z) {
				Vector3 spawnpos = new Vector3 (startpos.x, 0f, i);
				//Instantiate (road, spawnpos, Quaternion.identity);
				spawnlog.Add (spawnpos);
			}
		}

		if (tossROL == 2) {
			for (float i = startpos.x; i <= rightborder; i= i+roadSize.x) {
				Vector3 spawnpos = new Vector3 (i, 0f, startpos.z);
				//Instantiate (road, spawnpos, Quaternion.identity);
				spawnlog.Add (spawnpos);
				lastSpawned.Add(spawnpos);
			}
		} else {
			for (float i = startpos.x; i >= -rightborder; i= i-roadSize.x) {
				Vector3 spawnpos = new Vector3 (i, 0f, startpos.z);
				//Instantiate (road, spawnpos, Quaternion.identity);
				spawnlog.Add (spawnpos);
				lastSpawned.Add(spawnpos);
			}
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
				}
			} else {
				for (float i = startpos.x; i >= -rightborder; i= i-roadSize.x) {
					Vector3 spawnpos = new Vector3 (i, 0f, startpos.z);
					//Instantiate (road, spawnpos, Quaternion.identity);
					spawnlog.Add (spawnpos);
					lastSpawned.Add (spawnpos);
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
				}
			} else {
				for (float i = startpos.z; i >= -upperborder; i= i-roadSize.z) {
					Vector3 spawnpos = new Vector3 (startpos.x, 0f, i);
					//Instantiate (road, spawnpos, Quaternion.identity);
					spawnlog.Add (spawnpos);
					lastSpawned.Add(spawnpos);
				}
			}
		}


	}

	public void Generate() {
		//while (generateRoads) {
			Initialize ();

			int iter = 10;
	
		for (int i=1; i<=iter; i++) {
			CreateNext ();
		}

		spawnlog = getUnique (spawnlog);
		for (int i =0; i<spawnlog.Count; i++) {
			Instantiate(road, spawnlog[i], Quaternion.identity);
		}

//			if (spawnlog.Count >150) {
//				DestroyAllObjects();
//				Generate();
//			}
		//}

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

}
