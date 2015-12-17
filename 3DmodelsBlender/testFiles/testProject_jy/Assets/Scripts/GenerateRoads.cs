﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//INSTANTIATE AFTER SPAWNLOG IS DONE

public class GenerateRoads : MonoBehaviour {
	GameObject plane;
	float planeSize;
	public static GameObject road;
	static Vector3 roadSize;
	int sideLengthRelRoad;
	float upperborder;
	float rightborder;

	public List<Vector3> spawnlog;
	public List<int> directionslog;
	public List<Vector3> lastSpawned;

	
	void Initialize () {
		plane = CreateMap.plane;
		planeSize = plane.transform.localScale.x * 10; //plane is 10*scale by 10*scale
		Debug.Log ("planeSize: " + planeSize);
		road = Resources.Load ("road") as GameObject;
		roadSize = road.GetComponent<Renderer> ().bounds.size; //gets the size of the road tile using its renderer, should be (4, 0.2, 4)
		sideLengthRelRoad = (int) Mathf.Floor (planeSize / roadSize.x); //number of possible roadtiles on a side
		upperborder = planeSize/2 - roadSize.z/2; //z-value border relative to a roadtile
		rightborder = planeSize/2 - roadSize.x/2; //x-value relative to a roadtile
		spawnlog = new List<Vector3> ();
		directionslog = new List<int> ();
		lastSpawned = new List<Vector3> ();
		CreateFirstTiles ();
	}

	void CreateFirstTiles() {
		int tossUOD = Random.Range (0, 2); //0 = down, 1=up
		int tossROL = Random.Range (2, 4); //2 = right, 3 = left
		Debug.Log ("UOD: " + tossUOD + " ROL: " + tossROL);

		Vector3 startpos = new Vector3 (Random.Range (-rightborder, rightborder), 0f, Random.Range (-upperborder, upperborder));
		Debug.Log ("startpos: " + startpos);
		if (tossUOD == 1) {
			for (float i = startpos.z; i <= upperborder; i= i+roadSize.z) {
				Vector3 spawnpos = new Vector3 (startpos.x, 0f, i);
				Instantiate (road, spawnpos, Quaternion.identity);
				spawnlog.Add (spawnpos);
			}
		} else {
			for (float i = startpos.z; i >= -upperborder; i= i-roadSize.z) {
				Vector3 spawnpos = new Vector3 (startpos.x, 0f, i);
				Instantiate (road, spawnpos, Quaternion.identity);
				spawnlog.Add (spawnpos);
			}
		}

		if (tossROL == 2) {
			for (float i = startpos.x; i <= rightborder; i= i+roadSize.x) {
				Vector3 spawnpos = new Vector3 (i, 0f, startpos.z);
				Instantiate (road, spawnpos, Quaternion.identity);
				spawnlog.Add (spawnpos);
				lastSpawned.Add(spawnpos);
			}
		} else {
			for (float i = startpos.x; i >= -rightborder; i= i-roadSize.x) {
				Vector3 spawnpos = new Vector3 (i, 0f, startpos.z);
				Instantiate (road, spawnpos, Quaternion.identity);
				spawnlog.Add (spawnpos);
				lastSpawned.Add(spawnpos);
			}
		}

		directionslog.Add (tossUOD);
		directionslog.Add (tossROL);

	}

	void CreateNext() {
		int lastdir = directionslog [directionslog.Count - 1];

		int index = Random.Range (0, lastSpawned.Count); 
		Vector3 startpos = lastSpawned [index];

		int toss;

		lastSpawned = new List<Vector3> (); //empty lastspawned
		if (lastdir == 0 || lastdir == 1) {
			toss = Random.Range (2, 4);
			directionslog.Add(toss);
			if (toss == 2) {
				for (float i = startpos.x; i <= rightborder; i= i+roadSize.x) {
					Vector3 spawnpos = new Vector3 (i, 0f, startpos.z);
					Instantiate (road, spawnpos, Quaternion.identity);
					spawnlog.Add (spawnpos);
					lastSpawned.Add (spawnpos);
				}
			} else {
				for (float i = startpos.x; i >= -rightborder; i= i-roadSize.x) {
					Vector3 spawnpos = new Vector3 (i, 0f, startpos.z);
					Instantiate (road, spawnpos, Quaternion.identity);
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
					Instantiate (road, spawnpos, Quaternion.identity);
					spawnlog.Add (spawnpos);
					lastSpawned.Add(spawnpos);
				}
			} else {
				for (float i = startpos.z; i >= -upperborder; i= i-roadSize.z) {
					Vector3 spawnpos = new Vector3 (startpos.x, 0f, i);
					Instantiate (road, spawnpos, Quaternion.identity);
					spawnlog.Add (spawnpos);
					lastSpawned.Add(spawnpos);
				}
			}
		}


	}

	public void Generate() {
		Initialize ();

		int iter = 6;

		for (int i=1; i<=iter; i++) {
			CreateNext ();
		}

	}

}