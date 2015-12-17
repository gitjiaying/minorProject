using UnityEngine;
using System.Collections;

public class FollowShortestPath : MonoBehaviour 
{
	public Transform target;
    public Transform player;
	public Grid grid;
	public int speed = 10;
   

    void Awake()
	{
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
        Debug.Log(grid.path.Count);

        Vector3 targetPosition = new Vector3(target.position.x, this.transform.position.y, target.position.z);

        this.transform.LookAt(targetPosition);
        //Vector3 rot = this.transform.eulerAngles;
       // rot.y = -rot.y;
        //this.transform.eulerAngles = rot;

     
	}

	void moveTo(Vector3 Pos)
	{
        Vector3 transformTarget = new Vector3(transform.position.x, -2.2f, transform.position.z);
        transform.position = Vector3.MoveTowards(transformTarget, Pos, Time.deltaTime * speed);
	}


}
