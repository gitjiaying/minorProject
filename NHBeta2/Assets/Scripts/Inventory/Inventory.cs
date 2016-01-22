using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

    //inventory
	public static int Beers;
	public static int Energy;
    public static int BombBooks;
	// Use this for initialization
	void Start () {
	   Beers=0;
       Energy=0;
       BombBooks=0;
	}
	public static void clear(){
		Beers=0;
		Energy=0;
		BombBooks=0;
	}
}
