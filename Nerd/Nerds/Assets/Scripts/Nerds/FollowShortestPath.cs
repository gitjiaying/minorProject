using UnityEngine;
using System.Collections;

public class FollowShortestPath : MonoBehaviour 
{
	public Transform target;
	public Grid grid;

	void Awake()
	{
		grid = grid.GetComponent<Grid>();
	}
	// Update is called once per frame
	void Update () 
	{
		Debug.Log(grid.path.Count);
	}

}
