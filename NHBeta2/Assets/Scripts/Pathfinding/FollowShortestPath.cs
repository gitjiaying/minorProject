using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class FollowShortestPath : MonoBehaviour 
{
	private Transform target;
    private Transform player;
	public Grid grid;
	public int speed = 10;
	public float verticalOffset;


	public float radius = 0.5f;

	Vector3  rightBound;
	Vector3  leftBound;

	bool facingUnit;
	bool decisionReady = true;


	bool rightDominate;

	int right;

	float[][] WeightsIH; 
	float[][] WeightsHO;
 	float[][] HiddenOutput;
 	float[][] Yhidden;
 	float[] Xoutput;
 	float Youtput;
   

    void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		grid = grid.GetComponent<Grid>();
	}

	void Start(){


		FileInfo theSourceFile = new FileInfo 
        ("C:/Users/Ajdin/Downloads/UnitySpace/Episode4/Assets/Scenes/WeightsIH.txt");
        StreamReader reader = theSourceFile.OpenText();
        FileInfo theSourceFile2 = new FileInfo
        ("C:/Users/Ajdin/Downloads/UnitySpace/Episode4/Assets/Scenes/WeightsHO.txt");
        StreamReader reader2 = theSourceFile2.OpenText();

    	WeightsIH = CreateWeights(reader);
    	WeightsHO = CreateWeights(reader2);

    	Yhidden = new float[50][];
    	HiddenOutput = new float[50][];
    	Xoutput = new float[1];
    
	}
	// Update is called once per frame
	void Update () 
	{
		float distance = Vector3.Distance(transform.position , target.position);
		Vector3 unitDirection = transform.position - target.position;
		float angle = Mathf.Asin(radius/distance);

		rightBound = RotateV3aboutY(unitDirection, -angle);
		leftBound  = RotateV3aboutY(unitDirection,  angle);

		Vector3 normalLeft = RotateV3aboutY(unitDirection, -(Mathf.PI/2+angle*3));
		Vector3 normalRight= RotateV3aboutY(unitDirection,  (Mathf.PI/2+angle*3));

		//Debug.DrawLine(target.position, target.position+target.forward*10, Color.red);
		//Debug.DrawLine(target.position, target.position+rightBound*10, Color.blue);
		//Debug.DrawLine(target.position, target.position+leftBound*10, Color.blue);

		//Debug.DrawLine(transform.position, transform.position+normalLeft*10, Color.red);
		//Debug.DrawLine(transform.position, transform.position+normalRight*10, Color.red);

		facingUnit = V3InDirectionRange(target.forward, leftBound, rightBound);

		float angleDifference = Vector3.Angle(unitDirection, target.forward);

		float leftAngleDifference = Vector3.Angle(leftBound, target.forward);
		float rightAngleDifference = Vector3.Angle(rightBound, target.forward);

		if(rightAngleDifference>leftAngleDifference){
			rightDominate = true; 
		}else{
			rightDominate = false;
		}

		if(distance<60 && decisionReady){
				float Sum = 0f;
				for(int i = 0; i<WeightsIH.Length; i++){
				float[] rowsHidden = new float[1];
				rowsHidden[0] = WeightsIH[i][0]*BoolToInt(facingUnit) + WeightsIH[i][1]*distance + WeightsIH[i][2]*angleDifference+WeightsIH[i][3]*BoolToInt(rightDominate);
				HiddenOutput[i] = rowsHidden;
				float[] rowsYhidden = new float[1];
				rowsYhidden[0] = 1f / (1f + Mathf.Exp(-1f*HiddenOutput[i][0]));
				Yhidden[i] = rowsYhidden;
		
				Sum += WeightsHO[i][0]*Yhidden[i][0]; 
				Xoutput[0] = Sum;	
				Youtput = (1f / (1f + Mathf.Exp(-1f*Xoutput[0])))*UnityEngine.Random.Range(0.0f,1.0f);
	
			}

				
			decisionReady = false;
		}
		else if(distance > 60){
			decisionReady = true;
		}

		if(Youtput<0.5){
				if(grid.NodeFromWorldPoint(target.position+normalLeft).walkable && angleDifference<160)
				transform.position = Vector3.MoveTowards(transform.position, target.position+normalLeft, speed*Time.deltaTime);
				else
				moveTo(grid.path[0].getWorldPos());
		}
		else{
				if(grid.NodeFromWorldPoint(target.position+normalRight).walkable && angleDifference<160)
				transform.position = Vector3.MoveTowards(transform.position, target.position+normalRight, speed*Time.deltaTime);
				else
				moveTo(grid.path[0].getWorldPos());
		}
	

		if(grid.path[0] != null)
		{
			//Debug.Log(grid.path[0].getWorldPos());
			moveTo(grid.path[0].getWorldPos());
        }
        if(grid.path.Count == 0)
        {
            
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

	public int BoolToInt(bool boolean){
		int integer = boolean?1:0;
		return integer;

	}

	public float[][] CreateWeights(StreamReader reader){
		int n = 0;
		float[][] Weights = new float[50][];

		while((!reader.EndOfStream)){
			string text = reader.ReadLine();
	            if (text == null)
	    		break;

	    	string[] strFloats = text.Split (new char[0]);
	    	float[] floats = new float[strFloats.Length];
	    	for(int i = 0; i<strFloats.Length; i++){
            	floats[i] = float.Parse(strFloats[i]);
            	
            }
            Weights[n] = floats;
            n++;
		}
		return Weights;
	}

	public bool V3InDirectionRange(Vector3 forward, Vector3 left, Vector3 right){
		float angleLeftBound = Mathf.Atan(left.z/left.x);
		float angleRightBound = Mathf.Atan(right.z/right.x);
		float angleForward = Mathf.Atan(forward.z/forward.x);

		return (angleForward<=angleLeftBound && angleForward>=angleRightBound)?true:false;
	}

	public Vector3 RotateV3aboutY(Vector3 vector, float angle){
		Vector3 newVector;
		newVector.x = Mathf.Cos(angle)*vector.x - Mathf.Sin(angle)*vector.z;
		newVector.y = vector.y;
		newVector.z = Mathf.Sin(angle)*vector.x + Mathf.Cos(angle)*vector.z;

		return newVector;
	}



}
