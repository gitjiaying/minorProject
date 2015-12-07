using UnityEngine;
using System.Collections;

public class Pickups : MonoBehaviour {

	private bool firstHP;
	private bool firstEP;
	public Canvas HPinfo;
	public Canvas EPinfo;
	private int gunNumber;

	//inventory
	public static int gunStage;
	public static int HPots;
	public static int EPots;

	void Start(){
		firstHP = true;
		firstEP = true;
		HPinfo.enabled = false;
		EPinfo.enabled = false;
		gunStage = 0;
		HPots = 0;
		EPots = 0;
		gunNumber = 0;
	}
	void OnTriggerEnter(Collider other){

		if (other.gameObject.CompareTag("HP"))
		{
			HPots ++;
			other.gameObject.SetActive(false);

			if (firstHP){
				firstHP=false;
				HPinfo.enabled=true;
				Invoke("clearInfo",4f);
			}
		}
		if (other.gameObject.CompareTag("EP"))
		{
			EPots ++;
			other.gameObject.SetActive(false);

			if (firstEP){
				firstEP=false;
				EPinfo.enabled=true;
				Invoke("clearInfo",4f);
			}
		}
		if (other.gameObject.CompareTag("pistol"))
		{
			gunStage = 1;
			other.gameObject.SetActive(false);
		}
		if (other.gameObject.CompareTag("gun"))
		{
			gunStage = 2;
			other.gameObject.SetActive(false);
		}
		if (other.gameObject.CompareTag("machinegun"))
		{
			gunStage = 3;
			other.gameObject.SetActive(false);
		}
	}

	void clearInfo(){
		HPinfo.enabled = false;
		EPinfo.enabled = false;
	}

	public void ClearInventory(){
		gunStage = 0;
		HPots = 0;
		EPots = 0;
	}

	void useHP(){
		if (Input.GetKeyDown("r")) {
			//playerhealth=playerhealth+100
		}
	}

	void useEP(){
		if (Input.GetKeyDown("e")){
			//playerstamina=playerstamina+100
		}
	}

	void changeGunNumber(){
		if(Input.GetAxis("Mouse ScrollWheel") > 0){
			gunNumber++;
		}
		if(Input.GetAxis("Mouse ScrollWheel") < 0){
			gunNumber--;
		}
		if (gunNumber > gunStage){
			gunNumber=gunStage;
		}
		if(gunNumber<0){
			gunNumber=0;
		}
	}
}