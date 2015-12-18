using UnityEngine;
using System.Collections;

public class GameScene : MonoBehaviour {
	public Canvas Over;
	public Canvas Pause;
	public GameObject nerd;
	public GameObject player;
	public int minX;
	public int maxX;
	public int minY;
	public int maxY;
	public int height;
	public int spawnTime;
	// Use this for initialization
	void Start () {
		GameManagerScript.alive = true;
		Over.enabled = false;
		Pause.enabled = false;
		InvokeRepeating ("spawn", 5, 5);
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameManagerScript.alive) {
			Over.enabled=true;
			Time.timeScale=0;
		}
		if (Input.GetKeyDown (KeyCode.P)) {
			Pause.enabled=true;
			Time.timeScale=0;
		}
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
