using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStamina : MonoBehaviour {

    public int startingStamina = 100;
    public static float currentStamina;
    public Slider StaminaSlider;
    public float RegenerationRate = 5;

    PlayerController playerController;

	void Awake () {
        
        currentStamina = startingStamina;

    }

    void Update ()
    {
        if (currentStamina != startingStamina)
        {
            Regenerate();
        }
    }

   

    public void Run (float amount)
    {
        currentStamina -= amount*Time.deltaTime;
        StaminaSlider.value = currentStamina;
        
    }

    public void Jump (float amount)
    {
        currentStamina -= amount;
        StaminaSlider.value = currentStamina;
    }

   void Regenerate()
    {
        currentStamina += RegenerationRate * Time.deltaTime;
        StaminaSlider.value = currentStamina;
    }
}
