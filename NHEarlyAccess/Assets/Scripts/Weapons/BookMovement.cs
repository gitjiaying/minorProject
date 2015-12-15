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
	}
	
	
	void Update ()
    {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Nerd")
        {
            nerdsHealth.TakeDamage(damagePerBook);
            Debug.Log("HIT");
        }
    }
}
