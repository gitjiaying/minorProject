using UnityEngine;
using System.Collections;

public class ChooseWeapon : MonoBehaviour {

    public bool launcher_ON = false;
    public bool Geo_ON = false;
    private GameObject BookLauncher;
    private GameObject GEOStatic;
    private Rigidbody rbPlayer;
   

    public Transform WeaponsSpawn;

	void Start ()
    {
        rbPlayer = GameObject.Find("Player").GetComponent<Rigidbody>();
        
	}

   
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && !launcher_ON)
        {
            BookLauncher = (GameObject)Instantiate(Resources.Load("Weapons/BookLauncher"), WeaponsSpawn.position, WeaponsSpawn.rotation);
            launcher_ON = true;
			Geo_ON=false;
			if(GEOStatic !=null){
				Destroy(GEOStatic);
			}
			GameManagerScript.geo=false;
			GameManagerScript.bookLauncher=true;
        } 

        if (Input.GetKeyDown(KeyCode.Alpha2) && !Geo_ON)
        {
			Destroy(BookLauncher);
			GEOStatic = (GameObject)Instantiate(Resources.Load ("Weapons/GEOStatic"), WeaponsSpawn.position, WeaponsSpawn.rotation);
            Geo_ON = true;
			launcher_ON = false;
			GameManagerScript.geo=true;
			GameManagerScript.bookLauncher=false;

			// launcher weer op false en nog deleten.
        }
	    
	}

    void FixedUpdate()
    {
        if (GameManagerScript.bookLauncher)
        {
            BookLauncher.transform.rotation = rbPlayer.transform.rotation;
            BookLauncher.transform.position = WeaponsSpawn.transform.position;
        }

        if (GameManagerScript.geo)
        {
            GEOStatic.transform.rotation = rbPlayer.transform.rotation;
            GEOStatic.transform.position = WeaponsSpawn.transform.position;
        }
    }
}
