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
    public int ymin = -20;
    public int ymax = 80;
    public float rotmultiplier = 1.25f;
    public CameraTurn CameraTurn;
    public ButtonTurn ButtonTurn;
    Animator anim;

    ChooseWeapon launcher_ON;
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
       // playerRigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        CameraTurn = GetComponent<CameraTurn>();
        ButtonTurn = GetComponent<ButtonTurn>();
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

    void Update ()
    {
        // CheckButton(); **oude camera**
        
    }

    void Move (float h, float v)
    {
        movement.Set(h, 0f, v);

        movement = movement.normalized * WalkSpeed * Time.deltaTime;

       // playerRigidbody.MovePosition(transform.position + movement);
        rb.transform.Translate( -movement);
        float rotation = CameraMouseMovementHorizontal.rotation*rotmultiplier;
        rb.transform.Rotate(0, rotation, 0);
        rotation = ClampAngle(rotation, ymin, ymax);
    }

    public void Jump(float stamina)
    {
        if (stamina >= 0)
        {
            rb.AddForce(new Vector3(0, jump, 0));
            //rb.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);

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
            rb.transform.Translate(-movement);
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
   
   }

    void Animating (float h, float v)
    {
        bool walking = (h!= 0f || v!= 0f) && !sprint ;
        bool running = (h!= 0f || v!= 0f)&& sprint;
        bool hitting = (Input.GetKey("mouse 0") && !launcher_ON);
        anim.SetBool("Walking", walking);
        anim.SetBool("Running", running);
        anim.SetBool("Hitting", hitting);
    }

    static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
        {
            angle += 360;
        }

        if (angle > 360)
        {
            angle -= 360;
        }
        return Mathf.Clamp(angle, min, max);
    }

    //**Voor oude camera**
    //    public void CheckButton()
    //    {
    //        float h = Input.GetAxisRaw("Horizontal");
    //        float v = Input.GetAxisRaw("Vertical"); 

    //        if ((v >= 0.1 )|| (h >= 0.1) || (h <= -0.1))
    //        {
    //            CameraTurn.enabled = true;
    //            ButtonTurn.enabled = false;
    //        }
    //        else
    //        {
    //            CameraTurn.enabled = false;
    //            ButtonTurn.enabled = true;
    //        }

    //    }
}
