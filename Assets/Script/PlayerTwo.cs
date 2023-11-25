using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTwo : MonoBehaviour
{
    public Transform groundCheck;
    public Transform denfece;
    public LayerMask groundLayer;

    public float horizontal;
    public float rangerDenfece;
    public float speed = 8f;
    public float jumpingPower = 8f;

    public Rigidbody2D rb_player;

    public bool canShoot, canHead;
    public bool isAI;
    private GameObject theBall, thePlayer;



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
            theBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(-200, 300));
        }
    }

    public void Shoot()
    {
        Debug.Log(canShoot);
        if (canShoot == true)
        {
            theBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(-200, 300));
        }
    }
}
