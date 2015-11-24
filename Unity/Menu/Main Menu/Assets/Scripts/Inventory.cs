using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

	public bool gun1;
	public bool gun2;
	public bool gun3;
	public int HPots;
	public int EPots;
	
	public void ClearInventory(){
		gun1 = false;
		gun2 = false;
		gun3 = false;
		HPots = 0;
		EPots = 0;
	}

}
