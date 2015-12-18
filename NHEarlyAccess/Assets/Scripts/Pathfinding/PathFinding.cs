using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathFinding : MonoBehaviour 
{

	private Transform target;
	private Transform seeker;
	public Grid grid;



	void Awake()
	{
		//grid = GetComponent<Grid>();
		seeker = this.transform;
		//GameObject targetObj = GameObject.FindGameObjectWithTag ("Player");
		target=GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void Update()
	{
		FindPath(seeker.position, target.position);
	}

	void FindPath(Vector3 startPos, Vector3 targetPos)
	{
		Node startNode = grid.NodeFromWorldPoint(startPos);
		Node targetNode = grid.NodeFromWorldPoint(targetPos);

		List<Node> OpenSet = new List<Node>();
		HashSet<Node> ClosedSet = new HashSet<Node>();
		OpenSet.Add(startNode);

		while (OpenSet.Count > 0)
		{
			Node currentNode = OpenSet[0];
			for(int i = 1; i < OpenSet.Count; i++)
			{
				if(OpenSet[i].fCost < currentNode.fCost || OpenSet[i].fCost == currentNode.fCost && OpenSet[i].hCost < currentNode.hCost)
				{
					currentNode = OpenSet[i];
				}
			}

			OpenSet.Remove(currentNode);
			ClosedSet.Add(currentNode);

			if(currentNode == targetNode)
			{
				RetracePath(startNode, targetNode);
				return;
			}

			foreach (Node neighbour in grid.GetNeighbours(currentNode))
			{
				if(!neighbour.walkable || ClosedSet.Contains(neighbour))
				{
					continue;
				}

				int newMovementCostToNeighbour = currentNode.gCost + GetDistance(currentNode, neighbour);
				if(newMovementCostToNeighbour < neighbour.gCost || !OpenSet.Contains(neighbour))
				{
					neighbour.gCost = newMovementCostToNeighbour;
					neighbour.hCost = GetDistance(neighbour, targetNode);
					neighbour.parent = currentNode;

					if(!OpenSet.Contains(neighbour))
						OpenSet.Add(neighbour);
				}

			}


		}

	}

	void RetracePath(Node startNode, Node endNode)
	{
		List<Node> path = new List<Node>();
		Node currentNode = endNode;

		while(currentNode != startNode)
		{
			path.Add(currentNode);
			currentNode = currentNode.parent;
		}

		path.Reverse();

		grid.path = path;
	}

	int GetDistance(Node nodeA, Node nodeB)
	{
		int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
		int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

		if(dstX > dstY)
			return 14*dstY+10*(dstX-dstY);

		return 14*dstX + 10*(dstY - dstX);
	}
	
}
