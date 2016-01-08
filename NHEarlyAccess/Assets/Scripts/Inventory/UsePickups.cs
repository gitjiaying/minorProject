using UnityEngine;
using System.Collections;

public class UsePickups : MonoBehaviour {

    public AudioSource errorSound;
    public PlayerController player;
    //public GameObject book;
	public PlayerHealth health;
	public int healthboost;
	public GeoShoot geo;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	   if (Input.GetKeyDown("r")) {
			useBeer();
		}
        if (Input.GetKeyDown("e")){
			useEnergy();
		}
        if (Input.GetKeyDown("t")){
            useBB();
        }
	}
    
    void useBeer(){
		if (Inventory.Beers==0){
            errorSound.Play();
        }else{
			Inventory.Beers --;
			player.WalkSpeed -= 3;
			player.SprintSpeed -= 4;
			geo.fireRate += .1f;
			if (health.currentHealth < health.startingHealth - healthboost) {
				health.currentHealth += healthboost;
			} else {
				health.currentHealth = health.startingHealth;
				Invoke ("normalSpeed", 5f);
			}
        }
	}

	void useEnergy(){
		if (Inventory.Energy == 0) {
			errorSound.Play ();
		} else {
			Inventory.Energy--;
			player.WalkSpeed += 2;
			player.SprintSpeed += 3;
			geo.fireRate -= .05f;
			Invoke ("normalEnergy", 5f);
		}
	}
    void useBB(){
		
	}
	void normalSpeed(){
		player.WalkSpeed += 3;
		player.SprintSpeed += 4;
		geo.fireRate -= .1f;
	}
	void normalEnergy(){
		player.WalkSpeed -= 2;
		player.SprintSpeed -= 3;
		geo.fireRate += .05f;
	}
}
