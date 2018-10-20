using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class PlayerController : MonoBehaviour {

    //--Movement variables--//
    public float speed;
    private Rigidbody2D rb2d;
    public float jumpForce;


    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    private Vector2 moveVelocity;
    private float moveInput;
    private bool isGrounded;
    //--Sound--//
    public AudioClip coinPickup;
    public AudioClip jumpClip;
    public AudioClip levelComplete;
  

    

    //--text variables--//
    public Text countText;    
    public Text winText;
        
    private int count;
    
    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();       
        count = 0;
        winText.text = "";
        SetCountText();              
	}

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        
        if(isGrounded == true && Input.GetKeyDown(KeyCode.UpArrow))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb2d.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKey(KeyCode.UpArrow) && isJumping == true)
        {
            if(jumpTimeCounter > 0)
            {
                rb2d.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            } else
            {
                isJumping = false;
            }

            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(jumpClip);
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            isJumping = false;
        }
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);
    }


   

    //--coin and coin sound--//
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);

            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(coinPickup);
            count = count + 1;
            SetCountText();
        }

        if (other.gameObject.CompareTag("End"))
        {
            other.gameObject.SetActive(true);
            winText.text = "You Win!";
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(levelComplete);            
        }        
    }

    void SetCountText()
    {
     countText.text = "Count: " + count.ToString();
    }  
}
