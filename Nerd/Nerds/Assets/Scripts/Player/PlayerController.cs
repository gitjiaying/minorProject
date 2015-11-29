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
    public bool sprint;
    Animator anim;

    private Rigidbody rb;
    GameObject player;
    GameObject ground;
    PlayerStamina playerStamina;
    Collision col;
    Vector3 movement;
    Rigidbody playerRigidbody;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStamina = player.GetComponent<PlayerStamina>();
        ground = GameObject.FindGameObjectWithTag("ground");
        playerRigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        Animating(h,v);

        //float MoveHorizontal = Input.GetAxis("Horizontal");
       // float MoveVertical = Input.GetAxis("Vertical");


       // Vector3 movement = new Vector3(MoveHorizontal, 0.0f, MoveVertical);
        //rb.AddForce(movement * WalkSpeed);

        if (Input.GetKey("left shift"))
        {
            Sprint(PlayerStamina.currentStamina);
            sprint = true;
        }

        if (Input.GetKeyUp("left shift") || PlayerStamina.currentStamina <=0f)
        {
            sprint = false;
        }

            if (Input.GetKeyDown("space") && canJump)
        {
            Jump(PlayerStamina.currentStamina);
        }

    }

    void Move (float h, float v)
    {
        movement.Set(h, 0f, v);

        movement = movement.normalized * WalkSpeed * Time.deltaTime;

        playerRigidbody.MovePosition(transform.position + movement);

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
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        movement.Set(h, 0f, v);

        // float MoveHorizontal = Input.GetAxis("Horizontal");
        // float MoveVertical = Input.GetAxis("Vertical");
        //  Vector3 movement = new Vector3(MoveHorizontal, 0.0f, MoveVertical);

        if (stamina >= 0)
        {
            movement = movement.normalized * SprintSpeed * Time.deltaTime;
            playerRigidbody.MovePosition(transform.position + movement);
            playerStamina.Run(SprintCost);

            //rb.AddForce(movement * SprintSpeed);
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

    void Animating (float h, float v)
    {
        bool walking = (h!= 0f || v!= 0f) && !sprint ;
        bool running = (h!= 0f || v!= 0f )&& sprint;
        bool hitting = (Input.GetKey("mouse 0"));
        anim.SetBool("Walking", walking);
        anim.SetBool("Running", running);
        anim.SetBool("Hitting", hitting);
    }
}
