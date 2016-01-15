using UnityEngine;
using System.Collections;

public class BookMovement : MonoBehaviour {

	public float MovementSpeed;
	public float tumble;
    public int damagePerBook = 40;
    public NerdsHealth nerdsHealth;

    private Rigidbody rb;
	
	void Start ()
    {
		rb = GetComponent<Rigidbody>();

		rb.AddForce(transform.forward * MovementSpeed * -100.0f);
		rb.angularVelocity = Random.insideUnitSphere * tumble;
		Invoke ("destroy", 5);
	}
	
	
	void Update ()
    {
	
	}

    void OnTriggerStay (Collider col)
    {
        Destroy(gameObject, 0.1f);

       
    }
	void destroy(){
		Destroy (gameObject);
	}
}
