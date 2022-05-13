using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PlayerControll1 : MonoBehaviour
{
    public float speed = 3f;
    private float movement;
    private float move;
    private int moreJump;
    public int moreJumpValue;
    private Rigidbody2D rigidBody;
    public float jumpheight;
    private bool isTouchingGround;
    private Animator PlayerAnimation;
    public Vector3 respawnPoint;
    private bool canDoubleJump;
    public int jumpCount;
    public Joystick joystick;
    // Start is called before the first frame update
    void Start()
    {
        moreJump = moreJumpValue;
        rigidBody = GetComponent<Rigidbody2D>();
        PlayerAnimation = GetComponent<Animator>();
        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        move = joystick.Horizontal;
        if (movement != 0f)
        {
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
        }
        else if(move != 0.3f)
        {
            rigidBody.velocity = new Vector2(move * speed, rigidBody.velocity.y);

        }

        if (movement > 0f || move > 0f)
        {
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
        else if(movement < 0f || move < 0f)
        {
            transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }

        if ((joystick.Vertical >= 0.5f || Input.GetButtonDown("Jump")) && isTouchingGround)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpheight);
            isTouchingGround = false;
        }

        PlayerAnimation.SetFloat("Speed", Mathf.Abs(rigidBody.velocity.x));
        PlayerAnimation.SetBool("Grounded", isTouchingGround);

        if (isTouchingGround == true)
        {
        moreJump = moreJumpValue;
        }
        //if (Input.GetKeyDown(KeyCode.Space) && moreJump > 0)
        //{
        //    rigidBody.velocity = Vector2.up * jumpheight;
        //    moreJump--;
        //}
        //else if (Input.GetKeyDown(KeyCode.Space) && moreJump == 0 && isTouchingGround == true)
        //{
        //rigidBody.velocity = Vector2.up * jumpheight;
        //}
        //if (isTouchingGround == false) {
        //    canDoubleJump = true;

        //}
        if (!isTouchingGround && Input.GetButtonDown("Jump") && moreJump > 0)
        {
            //float jumpVelocity = 10f;
            //rigidBody.velocity = Vector2.up * jumpheight;
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpheight);            
            //canDoubleJump = false;
            moreJump--;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            isTouchingGround = true;
        //canDoubleJump = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "falldetector")
        {
            transform.position = respawnPoint;
            SceneManager.LoadScene("GameOver");
        }
        if (other.tag == "checkpoint")
        {
            respawnPoint = other.transform.position;
        }
    }
}
