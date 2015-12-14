using UnityEngine;
using System.Collections;

public class ChooseWeapon : MonoBehaviour {

    public bool launcher_ON = false;
    public bool Geo_ON = false;
    private GameObject BookLauncher;
    private GameObject GEO;
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
            BookLauncher = (GameObject)Instantiate(Resources.Load("BookLauncher"), WeaponsSpawn.position, WeaponsSpawn.rotation);
            launcher_ON = true;
        } 

        if (Input.GetKeyDown(KeyCode.Alpha2) && !Geo_ON)
        {
            Geo_ON = (GameObject)Instantiate(Resources.Load("GEO"), WeaponsSpawn.position, WeaponsSpawn.rotation);
            Geo_ON = true;
        }
	    
	}

    void FixedUpdate()
    {
        if (launcher_ON)
        {
            BookLauncher.transform.rotation = rbPlayer.transform.rotation;
            BookLauncher.transform.position = WeaponsSpawn.transform.position;
        }

        if (Geo_ON)
        {
            GEO.transform.rotation = rbPlayer.transform.rotation;
            GEO.transform.position = WeaponsSpawn.transform.position;
        }
    }
}
