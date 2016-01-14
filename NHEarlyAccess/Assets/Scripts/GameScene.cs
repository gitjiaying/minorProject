using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameScene : MonoBehaviour {
	public Canvas Over;
	public Canvas Pause;
	public GameObject nerd;
	public GameObject player;
	public GameObject beer;
	public GameObject energy;
	public GameObject bb;
	public int minX;
	public int maxX;
	public int minY;
	public int maxY;
	public float height;
	public float popupHeight;
	public float spawnTime;
	public float popupTime;
	private float startTime;
	private bool hasDied;
	public Text scoreOver;
	public Text scorePause;

    void Start () {
		GameManagerScript.alive = true;
		Over.enabled = false;
		Pause.enabled = false;
		InvokeRepeating ("spawn", 5, spawnTime);
		InvokeRepeating ("popup", 5, popupTime);
		startTime = Time.time;
		hasDied = false;
	}
	
	void Update () {
		if (!GameManagerScript.alive) {
			Over.enabled=true;
            Time.timeScale=0;
		}
		if (Input.GetKeyDown (KeyCode.P)) {
			if(!GameManagerScript.pause){
				Pause.enabled=true;
				Time.timeScale=0;
				GameManagerScript.pause=true;
			}else {
				Pause.enabled=false;
				Time.timeScale=1;
				GameManagerScript.pause=false;
			}
		}
		if (!GameManagerScript.alive) {
			if(!hasDied){
				GameManagerScript.timeAlive=Time.time-startTime;
				hasDied=true;
			}
		}
		scoreOver.text = GameManagerScript.score.ToString();
		scorePause.text=GameManagerScript.score.ToString();
	}
		
	void spawn(){
		Vector3 pos = new Vector3 (Random.Range (minX, maxX), height, Random.Range (minY, maxY));
		Vector3 rot = new Vector3 (0, 0, 0);
		Instantiate(nerd, pos,Quaternion.Euler(rot));
	}
	void popup(){
		int rand = Random.Range (1, 4);
		Vector3 pos = new Vector3 (Random.Range (minX, maxX), popupHeight, Random.Range (minY, maxY));
		Vector3 rot = new Vector3 (0, 0, 0);

		switch (rand) {
		case 1:
			Instantiate (beer, pos, Quaternion.Euler (rot));
			break;
		case 2:
			rot = new Vector3 (-90, 0, 0);
			Instantiate (energy, pos, Quaternion.Euler (rot));
			break;
		case 3:
			Instantiate (bb, pos, Quaternion.Euler (rot));
			break;
		}
	}
}
