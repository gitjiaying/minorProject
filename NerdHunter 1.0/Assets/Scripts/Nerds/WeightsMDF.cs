using UnityEngine;
using System.Collections;
using System;
using System.IO;
 
public class WeightsMDF : MonoBehaviour
{
//string[] floats;
int n=0;
int o=0;
 float[][] WeightsIH; // = new float[93][];
 float[][] WeightsHO;
 float[][] HiddenOutput;
 float[][] Yhidden;
 float[] Xoutput;

 float Youtput1;
 float Youtput2;

private float InputX1;
private float InputX2;

	private string text;
	private string text2;

	float Sum = 0f;
	float Sum2 = 0f;

public Rigidbody player;
public Rigidbody enemy;

public float X = 10;

    void Start ()
    {


        FileInfo theSourceFile = new FileInfo 
        ("C:/Users/Ajdin/Downloads/UnitySpace/minorProject/Nerd/Nerds/Assets/Scenes/WeightsIH.txt");
        StreamReader reader = theSourceFile.OpenText();
        FileInfo theSourceFile2 = new FileInfo
        ("C:/Users/Ajdin/Downloads/UnitySpace/minorProject/Nerd/Nerds/Assets/Scenes/WeightsHO.txt");
        StreamReader reader2 = theSourceFile2.OpenText();

      
    	WeightsIH = new float[93][];
    	WeightsHO = new float[93][];
    	HiddenOutput = new float[93][];
    	Yhidden = new float[93][];

    	Xoutput = new float[2];

        while((!reader.EndOfStream))
        {
        	
            text = reader.ReadLine();
            if (text == null)
    		break;

            string[] strFloats = text.Split (new char[0]);
            float[] floats = new float[strFloats.Length];
            for(int i = 0; i<strFloats.Length; i++)
            {
            	floats[i] = float.Parse(strFloats[i]);
            }
            WeightsIH[n] =  floats;
            n++;

        }
        while((!reader2.EndOfStream))
        {
        	
        	text2 = reader2.ReadLine();
        	if (text2 == null)
        	break;

        	string[] strFloats2 = text2.Split (new char[0]);
        	float[] floats2 = new float[strFloats2.Length];
        	for(int i = 0; i<strFloats2.Length; i++)
        	{
        		floats2[i] = float.Parse(strFloats2[i]);
        	}
        	WeightsHO[o] = floats2;
        	o++;
        }

       // print(WeightsIH.Length);
       // print(WeightsIH[0][0]);
       // print(WeightsHO[0][0]);
       // print(WeightsHO.Length);
   	}
   		void Update()
   		{
		InputX1=(player.velocity.x)*5;	InputX2 = (player.velocity.z)*5;
			
			

			for(int i = 0; i<WeightsIH.Length; i++)
			{
				float[] rowsHidden = new float[1];
				rowsHidden[0] = WeightsIH[i][0]*InputX1 + WeightsIH[i][1]*InputX2;
				HiddenOutput[i] = rowsHidden;
				float[] rowsYhidden = new float[1];
				rowsYhidden[0] = (1f - Mathf.Exp(-1f*HiddenOutput[i][0])) / (1f + Mathf.Exp(-1f*HiddenOutput[i][0]));
				Yhidden[i] = rowsYhidden;
		
				
				Sum += WeightsHO[i][0]*Yhidden[i][0]; 
				Xoutput[0] = Sum;
				
				Sum2 += WeightsHO[i][1]*Yhidden[i][0]; 
				Xoutput[1] = Sum2;
				
				Youtput1 = (1f - Mathf.Exp(-1f*Xoutput[0])) / (1f + Mathf.Exp(-1f*Xoutput[0]));
				Youtput2 = (1f - Mathf.Exp(-1f*Xoutput[1])) / (1f + Mathf.Exp(-1f*Xoutput[1]));
				// //Xoutput[0] = WeightsHO[0][i]*Yhidden[i][0]
				//Debug.Log(Youtput1);
				
			}
			//Debug.Log(Youtput1);
			//Debug.Log(Youtput2);
			Debug.Log(enemy.velocity.x);
			Debug.Log(enemy.velocity.z);
			Sum = 0;
			Sum2 = 0;
			enemy.AddForce( new Vector3(Youtput1*X, 0.0f, Youtput2*X));
    	}
}
 
