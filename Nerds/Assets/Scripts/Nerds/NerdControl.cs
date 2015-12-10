using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;  
using System;

public class NerdControl : MonoBehaviour {
	float[] firstColumn;

	// Use this for initialization
	void Start () 
	{
		 try
	     {
         string line;
         // Create a new StreamReader, tell it which file to read and what encoding the file
         // was saved as
         StreamReader theReader = new StreamReader("C://Users//Ajdin//Downloads//UnitySpace//minorProject//Nerd//Nerds//Assets//ScenesWeightsIH.txt", Encoding.Default);
         // Immediately clean up the reader after this block of code is done.
         // You generally use the "using" statement for potentially memory-intensive objects
         // instead of relying on garbage collection.
         // (Do not confuse this with the using directive for namespace at the 
         // beginning of a class!)
	         using (theReader)
	         {
             // While there's lines left in the text file, do this:
	             do
	             {
	                 line = theReader.ReadLine();
	                     
	                 if (line != null)
	                 {
	                     string[] entries = line.Split(' ');
	                     if (entries.Length > 0)
	                     {	
	                     	 for(int i = 0; i<entries.Length; i++)
	                         {
	                         	firstColumn[i] = float.Parse(entries[i]);
	                        	Debug.Log(firstColumn[i]);
	                    	 }
	                     }
	                 }
	             }
             	 while (line != null);           
             
             theReader.Close();   
             }
	    }
	         // If anything broke in the try block, we throw an exception with information
	         // on what didn't work
	         catch (Exception e)
	        {
	             Console.WriteLine("{0}\n", e.Message);
	          
	        }
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Calculate outputs

	}


	
}
