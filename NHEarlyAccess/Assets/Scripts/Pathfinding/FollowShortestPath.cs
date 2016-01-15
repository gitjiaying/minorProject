﻿using UnityEngine;
using System.Collections;

public class FollowShortestPath : MonoBehaviour 
{
	public Transform target;
	public Grid grid;
	public int speed = 10;

	void Awake()
	{
		grid = grid.GetComponent<Grid>();
	}
	// Update is called once per frame
	void Update () 
	{
		if(grid.path.Count != null)
		{
			
			moveTo(grid.path[0].worldPosition);
		}

	}

	void moveTo(Vector3 Pos)
	{
		transform.position = Vector3.MoveTowards(transform.position, Pos, Time.deltaTime * speed);
	}

}
