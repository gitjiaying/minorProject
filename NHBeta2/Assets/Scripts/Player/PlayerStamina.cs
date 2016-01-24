using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStamina : MonoBehaviour {

	public static float startingStamina = 100f;
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
   void Regenerate()
    {
        currentStamina += RegenerationRate * Time.deltaTime;
        StaminaSlider.value = currentStamina;
    }
}
