﻿using UnityEngine;
using System.Collections;

public class Node 
{
	public bool walkable; //ook spawnable
	public Vector3 worldPosition;

	public int gCost;
	public int hCost;

	public int gridX;
	public int gridY;

	public Node parent;

	public Node(bool _walkable, Vector3 _worldPos, int _gridX, int _gridY)
	{
		walkable = _walkable;
		worldPosition = _worldPos;
		gridX = _gridX;
		gridY = _gridY;
	}

	public int fCost {
		get {
			return gCost + hCost;
		}
	}

	public Vector3 getWorldPos()
	{
		return worldPosition;
	}

}
