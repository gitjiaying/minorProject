using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public int WalkSpeed = 5;
    public int SprintSpeed = 10;
    public float SprintCost = 10;
    public float JumpCost = 20;
    public float jump;
    public bool canJump = true;

    private Rigidbody rb;
    GameObject player;
    GameObject ground;
    PlayerStamina playerStamina;
    Collision col;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStamina = player.GetComponent<PlayerStamina>();
        ground = GameObject.FindGameObjectWithTag("ground");
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {

        float MoveHorizontal = Input.GetAxis("Horizontal");
        float MoveVertical = Input.GetAxis("Vertical");


        Vector3 movement = new Vector3(MoveHorizontal, 0.0f, MoveVertical);
        rb.AddForce(movement * WalkSpeed);

        if (Input.GetKey("left shift"))
        {
            Sprint(PlayerStamina.currentStamina);
        }

        if (Input.GetKeyDown("space") && canJump)
        {
            Jump(PlayerStamina.currentStamina);
        }

    }

    public void Jump(float stamina)
    {
        if (stamina >= 0)
        {
            rb.AddForce(new Vector3(0, jump, 0));
            canJump = false;
            playerStamina.Jump(JumpCost);
        }
        

    }


    public void Sprint(float stamina)
    {

        float MoveHorizontal = Input.GetAxis("Horizontal");
        float MoveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(MoveHorizontal, 0.0f, MoveVertical);

        if (stamina >= 0)
        {
            rb.AddForce(movement * SprintSpeed);
            playerStamina.Run(SprintCost);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "ground")
     {
         canJump = true;
     }
     else
     {
         canJump = false;
       }
   }
}
