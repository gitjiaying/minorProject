using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameScene : MonoBehaviour {
	public Canvas Over;
	public Canvas Pause;
	public GameObject nerd;
    public GameObject ubernerd;
    public GameObject nerdsprinter;
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
    public static float counter;
	public Text scoreOver;
	public Text scorePause;
    public int uberRate;
    public int sprinterRate;
    public Text score;
	public Canvas Options;

	private AudioSource source;
	private float random;

	int lastUberCount;
	int lastSprinterCount;

    void Start () {
		Cursor.visible = false;
		GameManagerScript.alive = true;
		Over.enabled = false;
		Pause.enabled = false;
		InvokeRepeating ("spawn", 5, spawnTime);
		InvokeRepeating ("popup", 5, popupTime);
		startTime = Time.time;
		hasDied = false;
        counter = 0;
		GameManagerScript.score = 0;
		source = GetComponent<AudioSource>();

		lastUberCount =0;
		lastSprinterCount =0;
	}
	
	void Update () {
        score.text = GameManagerScript.score.ToString();
        counter += Time.deltaTime;
		if (!GameManagerScript.alive) {
			Over.enabled=true;
            Time.timeScale=0;
		}
		if (Input.GetKeyDown (KeyCode.Escape)&&GameManagerScript.alive) {
			if(!GameManagerScript.pause){
				Pause.enabled=true;
				Time.timeScale=0;
				Cursor.visible = true;
				GameManagerScript.pause=true;
			}else {
				Pause.enabled=false;
				Options.enabled = false;
				Time.timeScale=1;
				GameManagerScript.pause=false;
				Cursor.visible = false;
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
		
        if (GameManagerScript.nerdsKilled % uberRate == 0 && GameManagerScript.nerdsKilled > lastUberCount) 
        {
            pos = new Vector3(Random.Range(minX, maxX), height, Random.Range(minY, maxY));
            Instantiate(ubernerd, pos, Quaternion.Euler(rot));
			source.PlayOneShot((AudioClip)Resources.Load("Music/Effects/zombie_1"));
            Debug.Log("ubernerd spawned");
			lastUberCount+= uberRate;
        }
        if (GameManagerScript.nerdsKilled % sprinterRate == 0 && GameManagerScript.nerdsKilled > lastSprinterCount)
        {
            pos = new Vector3(Random.Range(minX, maxX), height, Random.Range(minY, maxY));
            Instantiate(nerdsprinter, pos, Quaternion.Euler(rot));

			random = Random.Range(0,1);

			if(random < 0.5){
				source.PlayOneShot((AudioClip)Resources.Load("Music/Effects/nanana"));
			}else if(random > 0.5){
				source.PlayOneShot((AudioClip)Resources.Load("Music/Effects/nonono"));
			}

            Debug.Log("SprinterNerd spawned");
			lastSprinterCount += sprinterRate;
        }
    }
	void popup(){
		int rand = Random.Range (1, 4);
		Vector3 pos = new Vector3 (Random.Range (minX, maxX), popupHeight, Random.Range (minY, maxY));
		Vector3 rot = new Vector3 (-90, 0, 0);

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
