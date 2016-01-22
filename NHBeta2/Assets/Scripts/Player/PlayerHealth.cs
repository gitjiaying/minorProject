using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using LitJson;
using System.Collections.Generic;

public class PlayerHealth : MonoBehaviour {

    public PlayerController playerController;
    public int startingHealth = 100;
    public float currentHealth;
    public Slider healthSlider;
	private List<int> highscores;

	private JsonData obj;

	private string Url = "http://drproject.twi.tudelft.nl:8085/postScore";

    bool isDead = false;
    bool damaged;
    ParticleSystem hitParticles;

	//visual red feedback created on the HUDCanvas by a canvas filling damageImage;
	public Image damageImage; 
	public float flashSpeed = 5f;                              
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f); 

    void Awake () {

        currentHealth = startingHealth;
        hitParticles = GetComponentInChildren<ParticleSystem>();
    }
	void Update() {
		healthSlider.value = currentHealth;
		// If the player has just been damaged...
		if(damaged)
		{
			// ... set the colour of the damageImage to the flash colour.
			damageImage.color = flashColour;
		}
		// Otherwise...
		else
		{
			// ... transition the colour back to clear.
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		
		// Reset the damaged flag.
		damaged = false;
	}
	
	void Start()
    {
        playerController = playerController.GetComponent<PlayerController>();
    }

    public void TakeDamage (float amount)
    {
        damaged = true;
        currentHealth -= amount;
        hitParticles.Play();

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    void Death ()
    {
        isDead = true;
        playerController.enabled = false;
		GameManagerScript.scores.Add(GameManagerScript.score);
		sortHighscores ();
		sendHS ();
		GameManagerScript.alive = false;
		Cursor.visible = true;
    }

	void sendHS(){
		obj = JsonMapper.ToJson(highscores);// Gebruik toJson om json van list te maken.
		StartCoroutine(sendScore(obj));
	}

	IEnumerator sendScore(JsonData obj)
	{
		WWWForm dataParameters = new WWWForm();
		dataParameters.AddField("scores", obj.ToString()); // stuur altijd als string.
		dataParameters.AddField("UserId" , LoginScript.userID);
		WWW www = new WWW(Url,dataParameters);
		yield return www;
	}
	void sortHighscores(){
		highscores = new List<int> ();
		List<int> scores = GameManagerScript.scores;
		for (int i=0; i<scores.Count; i++) {
			Debug.Log (scores[i].ToString());
		}
		scores.Sort ();
		scores.Reverse ();
		Debug.Log ("sorted");
		for (int i=0; i<scores.Count; i++) {
			Debug.Log (scores[i].ToString());
		}

		for (int i = 0; i<Mathf.Min(5,scores.Count); i++) {
			if(scores[i] !=null){
				highscores.Add(scores[i]);
			}
		}
		Debug.Log ("highscores made");
	}
}
