using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Transform groundCheck;
    public LayerMask groundLayer;

    public float horizontal;
    public float speed = 8f;
    public float jumpingPower = 8f;

    public int shootingPowerX = 200;
    public int shootingPowerY = 300;

    public Rigidbody2D rb_player;

    public bool canShoot;
    public bool canHead;
    private GameObject theBall;

    public int hashShoot, hashJump, hashMoveFW, hashMoveBW;
    public Animator theAniPlayer;

    public AudioSource kick;


    // Start is called before the first frame update
    void Start()
    {
        rb_player = GetComponent<Rigidbody2D>();
        theBall = GameObject.FindGameObjectWithTag("Ball");

        hashShoot = Animator.StringToHash("Shoot");
        hashJump = Animator.StringToHash("Jump");
        hashMoveBW = Animator.StringToHash("MoveBW");
        hashMoveFW = Animator.StringToHash("MoveFW");
    }
    private void FixedUpdate()
    {
        /*rb_player.velocity = new Vector2(Time.deltaTime * speed * horizontal, rb_player.velocity.y);*/
        rb_player.velocity = new Vector2(speed * horizontal, rb_player.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

   /* private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            *//*theAniPlayer.SetBool("Jump", false);*//*
        }
    }
*/
    /*private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            theAniPlayer.SetBool("Jump", true);
        }
    }*/


    public void Move(InputAction.CallbackContext context)
    {

        horizontal = context.ReadValue<Vector2>().x;

        if (isGrounded())
        {
            if (horizontal > 0)
            {
                theAniPlayer.SetTrigger("MoveFW");
            }
            else if (horizontal < 0)
            {
                theAniPlayer.SetTrigger("MoveBW");
            }
        }
        
    }
    public void Jump(InputAction.CallbackContext context)
    {

        if (context.performed && isGrounded())
        {
            theAniPlayer.SetTrigger("Jump");
            rb_player.velocity = new Vector2(rb_player.velocity.x, jumpingPower);
        }
        if(context.canceled && rb_player.velocity.y > 0f)
        {
            rb_player.velocity = new Vector2(rb_player.velocity.x, rb_player.velocity.y * 0.5f);
        }
     
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        Debug.Log(canShoot);
        if(canShoot == true && context.performed)
        {
            theAniPlayer.SetTrigger("Shoot");
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
            theBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(300, 500));
        }
    }
}
