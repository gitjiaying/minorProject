using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public int WalkSpeed = 5;
    public int SprintSpeed = 10;
    public float SprintCost = 10;
    public bool sprint;
    public int ymin = -20;
    public int ymax = 80;
    public float rotmultiplier = 1.25f;
    public CameraTurn CameraTurn;
    public ButtonTurn ButtonTurn;
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
    }


    void Move (float h, float v)
    {
        movement.Set(h, 0f, v);

        movement = movement.normalized * WalkSpeed * Time.deltaTime;

        rb.transform.Translate( -movement);
        float rotation = CameraMouseMovementHorizontal.rotation*rotmultiplier;
        rb.transform.Rotate(0, rotation, 0);
        rotation = ClampAngle(rotation, ymin, ymax);
    }




    public void Sprint(float stamina)
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        movement.Set(h, 0f, v);

        if (stamina >= 0)
        {
            movement = movement.normalized * SprintSpeed * Time.deltaTime;
            rb.transform.Translate(-movement);
            playerStamina.Run(SprintCost);
        }
       
    }
		
    void Animating (float h, float v)
    {
        bool walking = (h!= 0f || v!= 0f) && !sprint ;
        bool running = (h!= 0f || v!= 0f )&& sprint;
        bool hitting = (Input.GetKey("mouse 1"));
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
}
