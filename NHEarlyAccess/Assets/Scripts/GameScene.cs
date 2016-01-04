using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameScene : MonoBehaviour {
	public Canvas Over;
	public Canvas Pause;
	public GameObject nerd;
	public GameObject player;
	public int minX;
	public int maxX;
	public int minY;
	public int maxY;
	public float height;
	public float spawnTime;
	private float startTime;
	private bool hasDied;
	public Text scoreOver;
	public Text scorePause;
	// Use this for initialization
	void Start () {
		GameManagerScript.alive = true;
		Over.enabled = false;
		Pause.enabled = false;
		InvokeRepeating ("spawn", 5, spawnTime);
		startTime = Time.time;
		hasDied = false;
	}
	
	// Update is called once per frame
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

	void NerdSpawner(){
		InvokeRepeating ("Spawn", 0, spawnTime);
		
	}
	void spawn(){
		Vector3 pos = new Vector3 (Random.Range (minX, maxX), height, Random.Range (minY, maxY));
		Vector3 rot = new Vector3 (0, 0, 0);
		Instantiate(nerd, pos,Quaternion.Euler(rot));
	}
}
