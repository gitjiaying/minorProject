#pragma strict


	var gridSize : Vector3 = new Vector3(1,1,1);
 	var movementDirection : Vector3 = new Vector3(0,0,1);
 
 function Start () {
     InvokeRepeating("UpdatePosition", 1.0, 1.0);
 }
 
 function UpdatePosition () {
     var newPos : Vector3 = transform.position+movementDirection;
     newPos = Vector3(Mathf.Round(newPos.x/gridSize.x)*gridSize.x,
                      Mathf.Round(newPos.y/gridSize.y)*gridSize.y,
                      Mathf.Round(newPos.z/gridSize.z)*gridSize.z);
     transform.position = newPos;
 }