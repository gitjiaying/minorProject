using UnityEngine;
using System.Collections;

public class Pickups : MonoBehaviour {

	private bool firstBeer;
	private bool firstEnergy;
    private bool firstBB;
	public GameObject BeerInfo;
	public GameObject EnergyInfo;
	public GameObject BBInfo;

	void Start(){
		firstBeer = true;
		firstEnergy = true;
        firstBB = true;
		BeerInfo.SetActive(false);
		EnergyInfo.SetActive(false);
		BBInfo.SetActive(false);
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag("Beer"))
		{
			Inventory.Beers ++;
			Debug.Log (Inventory.Beers + " beers");
			other.gameObject.SetActive(false);

			if (firstBeer){
				firstBeer=false;
				BeerInfo.SetActive(true);
				Invoke("clearInfo",4f);
			}
		}
		if (other.gameObject.CompareTag("Energy"))
		{
			Inventory.Energy ++;
			other.gameObject.SetActive(false);

			if (firstEnergy){
				firstEnergy=false;
				EnergyInfo.SetActive(true);
				Invoke("clearInfo",4f);
			}
		}
        if (other.gameObject.CompareTag("BB"))
		{
			Inventory.BombBooks ++;
			other.gameObject.SetActive(false);

			if (firstBB){
				firstBB=false;
				BBInfo.SetActive(true);
				Invoke("clearInfo",4f);
			}
		}
	}

	void clearInfo(){
		BeerInfo.SetActive(false);
		EnergyInfo.SetActive(false);
		BBInfo.SetActive(false);
	}
}