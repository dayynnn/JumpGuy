using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontal;
    private float jumpingPwr = 16f;
    private bool isFacingRight = true;


    [SerializeField] private ObstacleManager obstacleManager;
    
    
    private bool isGrounded;
    private Animator anim;
    public CoinManager coinManager;

    [SerializeField] private Rigidbody2D myRigidBody;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float speed;
    [SerializeField] private int value;
   
    Animator animator;
   
    
    private void Awake()
    {
        anim = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();  
    }
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
        Flip();
    }

    void Movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(horizontalInput * Time.deltaTime * speed , 0, 0); // * BY SPEED CONST TO CONTROL PLAYER SPEED
       
        //Flip player when moving left-right       
        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(1, (float)1.8, 1);
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, (float)1.8, 1);
        }

        // Set animator parameters
        anim.SetBool("Run", horizontalInput != 0);
        anim.SetBool("IsGrounded", isGrounded);

    }

    private void Speed()
    {
        myRigidBody.velocity = new Vector2(horizontal * speed, myRigidBody.velocity.y);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded())
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpingPwr);
            isGrounded = false;
            anim.SetTrigger("Jump");
            isGrounded = true;
        }
        if(Input.GetKeyUp(KeyCode.UpArrow) && myRigidBody.velocity.y > 0f) //jump higher or lower depending on the time the button's pressed
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, myRigidBody.velocity.y * 0.5f);
        }
    }

    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }



    void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;

        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectible")) 
        {
            Debug.Log("Coin Collected");
            //collectibleManager.ChangeCoins(value);
            Destroy(other.gameObject);
            coinManager.coinCount++;

        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        //isGrounded = true;
        //animator.SetBool("isJumping", !isGrounded);
        if(col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }

        if (col.gameObject.name == "Obstacle")
        {
           Debug.Log("Obstacle Hit");
        }
    }
}
