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

    public Rigidbody2D rb_player;

    public bool canShoot, canHead;
    private GameObject theBall;


    // Start is called before the first frame update
    void Start()
    {
        rb_player = GetComponent<Rigidbody2D>();
        theBall = GameObject.FindGameObjectWithTag("Ball");
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

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    public void Move(InputAction.CallbackContext context)
    {
            horizontal = context.ReadValue<Vector2>().x;   
    }
    public void Jump(InputAction.CallbackContext context)
    {
        

        if (context.performed && isGrounded())
        {
            rb_player.velocity = new Vector2(rb_player.velocity.x, jumpingPower);
            if(canHead == true)
            {
                Head();
            }
        }
        if(context.canceled && rb_player.velocity.y > 0f)
        {
            rb_player.velocity = new Vector2(rb_player.velocity.x, rb_player.velocity.y * 0.5f);
        }
        /*else
        {
            rb_player.velocity = new Vector2(rb_player.velocity.x, jumpingPower);
        }*/
    }
    public void Shoot(InputAction.CallbackContext context)
    {
        Debug.Log(canShoot);
        if(canShoot == true)
        {
            theBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(200, 250));
        }
    }

    public void Head()
    {
        if(canHead == true)
        {
            theBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(200, 250));
        }
    }
}
