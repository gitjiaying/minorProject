using UnityEngine;
using System.Collections;

public class UsePickups : MonoBehaviour {

    public AudioSource errorSound;
    public PlayerController player;
	public PlayerHealth health;
	public int healthboost;
	public GeoShoot geo;
	public int stamboost;
	
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
        //if the player has at least one beer, he will use it and walk/sprint slower, and take longer between shots for 5 seconds. He will also gain health (boost amount) with max at starting health
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
			}
			Invoke ("normalSpeed", 5f);
        }
	}

	void useEnergy(){
        //if the player has at least one energy drink, he wil use it and gain a boost of stamina
        if (Inventory.Energy == 0) {
			errorSound.Play ();
		} else {
			Inventory.Energy--;
			if (PlayerStamina.currentStamina < PlayerStamina.startingStamina - stamboost) {
				PlayerStamina.currentStamina += stamboost;
			} else {
				PlayerStamina.currentStamina = PlayerStamina.startingStamina;
			}
		}
	}
    void useBB(){
        //if the player has at least one bombbooks he wil use it and books wil become exploding for 5 seconds;
        if (Inventory.BombBooks == 0) {
			errorSound.Play ();
		} else {
			Inventory.BombBooks--;
			GameManagerScript.bookEx = true;
			Invoke ("normalBooks", 10f);
		}
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
	void normalBooks(){
		GameManagerScript.bookEx = false;
	}
}
