using UnityEngine;
using System.Collections;

public class GeoMovement : MonoBehaviour
{

    public float MovementSpeed;
    public float tumble;
    private Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.AddForce(transform.up * MovementSpeed * -100.0f);
        rb.angularVelocity = Random.insideUnitSphere * tumble;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
