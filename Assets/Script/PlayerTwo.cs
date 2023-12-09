using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTwo : MonoBehaviour
{
    public static PlayerTwo instance;

    public Transform groundCheck;
    public Transform denfece;
    public LayerMask groundLayer;

    public float horizontal;
    public float rangerDenfece;
    public float speed = 8f;
    public float jumpingPower = 8f;

    public Rigidbody2D rb_player;

    public int shootingPowerX = -200;
    public int shootingPowerY = 300;

    public bool canShoot, canHead;
    public bool isAI;
    private GameObject theBall, thePlayer;

    public int hashShoot, hashJump, hashMoveFW, hashMoveBW;
    public Animator theAniOpp;

    public AudioSource kick;


    // Start is called before the first frame update
    void Start()
    {
        rb_player = GetComponent<Rigidbody2D>();
        theBall = GameObject.FindGameObjectWithTag("Ball");
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        if(isAI == true)
        {
            speed = 300f;
        }

        hashShoot = Animator.StringToHash("Shoot");
        hashJump = Animator.StringToHash("Jump");
        hashMoveBW = Animator.StringToHash("MoveBW");
        hashMoveFW = Animator.StringToHash("MoveFW");
    }
    private void FixedUpdate()
    {
        /*rb_player.velocity = new Vector2(Time.deltaTime * speed * horizontal, rb_player.velocity.y);*/
        if(isAI == true)
        {
            Move();
            if(canShoot == true)
            {
                Shoot();
            }
            if (isGrounded())
            {
                Jump();
            }
        }
        else if(isAI == false)
        {
            rb_player.velocity = new Vector2(speed * horizontal, rb_player.velocity.y);
        }
        

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Cek apakah menapak tanah
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    //Move method untuk P2
    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;

        if (isGrounded())
        {
            if (horizontal > 0)
            {
                theAniOpp.SetTrigger("MoveBW");
            }
            else if (horizontal < 0)
            {
                theAniOpp.SetTrigger("MoveFW");
            }
        }
        
    }

    //Move method untuk AI
    public void Move()
    {
        if (Mathf.Abs(theBall.transform.position.x - transform.position.x) < rangerDenfece)
        {
            if (theBall.transform.position.x > transform.position.x && theBall.transform.position.y <-1f
                && Mathf.Abs(theBall.transform.position.x - transform.position.x) <= Mathf.Abs(theBall.transform.position.x - thePlayer.transform.position.x ))
            {
                rb_player.velocity = new Vector2(Time.deltaTime * speed, rb_player.velocity.y);
            }
            else if (theBall.transform.position.y >= -1f && transform.position.x <= denfece.position.x)
            {
                rb_player.velocity = new Vector2(0, rb_player.velocity.y);
            }
            else 
            {
                rb_player.velocity = new Vector2(-Time.deltaTime * speed, rb_player.velocity.y);
            }
        }
        else
        {
            if (transform.position.x > denfece.position.x)
            {
                rb_player.velocity = new Vector2(-Time.deltaTime * speed, rb_player.velocity.y);
            }
            else
            {
                rb_player.velocity = new Vector2(0, rb_player.velocity.y);
            }
        }
    }
    public void Jump(InputAction.CallbackContext context)
    {

        if (context.performed && isGrounded())
        {
            theAniOpp.SetTrigger("Jump");
            rb_player.velocity = new Vector2(rb_player.velocity.x, jumpingPower);
        }
        if (context.canceled && rb_player.velocity.y > 0f)
        {
            rb_player.velocity = new Vector2(rb_player.velocity.x, rb_player.velocity.y * 0.5f);
        }
    }
    public void Jump()
    {
        if (isAI == true)
        {
            if (isGrounded())
            {
                rb_player.velocity = new Vector2(rb_player.velocity.x, jumpingPower);
            }
            if (rb_player.velocity.y > 0f)
            {
                rb_player.velocity = new Vector2(rb_player.velocity.x, rb_player.velocity.y * 0.5f);
            }
        }
      
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        Debug.Log(canShoot);
        if (canShoot == true)
        {
            theAniOpp.SetTrigger("Shoot");
            kick.Play();
            theBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(shootingPowerX, shootingPowerY));
            
        }
    }

    public void Shoot()
    {
        Debug.Log(canShoot);
        if (canShoot == true)
        {
            theAniOpp.SetTrigger("Shoot");
            kick.Play();
            theBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(shootingPowerX, shootingPowerY));
        }
    }

    public void Head()
    {
        if (canHead == true)
        {
            rb_player.velocity = new Vector2(rb_player.velocity.x, jumpingPower);
            theBall.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            theBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(-300, 500));
        }
    }
}
