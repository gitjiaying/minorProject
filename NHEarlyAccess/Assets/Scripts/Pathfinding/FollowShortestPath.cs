using UnityEngine;
using System.Collections;

public class FollowShortestPath : MonoBehaviour 
{
	private Transform target;
    private Transform player;
	public Grid grid;
	public int speed = 10;
	public float verticalOffset;
   

    void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		grid = grid.GetComponent<Grid>();
	}
	// Update is called once per frame
	void Update () 
	{
		if(grid.path[0] != null)
		{
			//Debug.Log(grid.path[0].getWorldPos());
			moveTo(grid.path[0].getWorldPos());
        }
        if(grid.path.Count == 0)
        {
            Debug.Log(grid.path.Count);
            Vector3 transformPlayer = new Vector3(player.position.x,0.0f, player.position.z);
            moveTo(transformPlayer);
        }

        Vector3 targetPosition = new Vector3(target.position.x, this.transform.position.y, target.position.z);

        this.transform.LookAt(targetPosition);
		this.transform.Rotate (0, 180, 0);

     
	}

	void moveTo(Vector3 Pos)
	{
        Vector3 transformTarget = new Vector3(transform.position.x, verticalOffset, transform.position.z);
        transform.position = Vector3.MoveTowards(transformTarget, Pos, Time.deltaTime * speed);
	}


}
