using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pickups : MonoBehaviour {

	private bool firstBeer;
	private bool firstEnergy;
    private bool firstBB;
	public Canvas BeerInfo;
	public Canvas EnergyInfo;
	public Canvas BBInfo;
	public Text cans;
	public Text beers;
	public Text bombs;

	void Start(){
		firstBeer = true;
		firstEnergy = true;
        firstBB = true;
		BeerInfo.enabled=false;
		EnergyInfo.enabled=false;
		BBInfo.enabled=false;
		Inventory.clear ();
	}
	void Update(){
		cans.text = Inventory.Energy.ToString();
		beers.text = Inventory.Beers.ToString();
		bombs.text = Inventory.BombBooks.ToString();
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag("Beer"))
		{
			Inventory.Beers ++;

			other.gameObject.SetActive(false);
			Debug.Log (firstBeer);

			if (firstBeer){
				firstBeer=false;
				BeerInfo.enabled = true;;
				Invoke("clearInfo",4f);
			}
			Debug.Log (Inventory.Beers + " beers");
		}
		if (other.gameObject.CompareTag("Energy"))
		{
			Inventory.Energy ++;
			other.gameObject.SetActive(false);

			if (firstEnergy){
				firstEnergy=false;
				EnergyInfo.enabled = true;;
				Invoke("clearInfo",4f);
			}
		}
        if (other.gameObject.CompareTag("BB"))
		{
			Inventory.BombBooks ++;
			other.gameObject.SetActive(false);

			if (firstBB){
				firstBB=false;
				BBInfo.enabled=true;
				Invoke("clearInfo",4f);
			}
		}
	}

	void clearInfo(){
		BeerInfo.enabled=false;
		EnergyInfo.enabled=false;
		BBInfo.enabled=false;
	}
}