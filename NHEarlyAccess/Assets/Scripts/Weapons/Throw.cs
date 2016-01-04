using UnityEngine;
using System.Collections;

public class Throw : MonoBehaviour
{

    public GameObject GEO;
    //public float fireRate;


    public Transform geoSpawn;
    private float nextFire;

    private Animation anim;

    // Use this for initialization
    void Start()
    {
        //anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("mouse 0")) //&& /*Time.time > nextFire*/ //!anim.IsPlaying("Default Take"))
        {

           // anim.Play("Default Take");
            Instantiate(GEO, geoSpawn.position, geoSpawn.rotation);

            //nextFire = Time.time + fireRate;
            /*Kan ook met aanpasbare fireRate
			 */
        }
    }

}
