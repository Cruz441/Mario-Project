using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class PlayerController : MonoBehaviour {

    //--Movement variables--//
    public float speed;    
    public AudioClip coinPickup;
    public AudioClip jumpClip;
    public float jumpForce;

    //--text variables--//
    public Text countText;    
    public Text winText;
    

    private Rigidbody2D rb2d;
    private int count;
    
    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();       
        count = 0;
        SetCountText();              
	}
	
    //--left and right movement--//
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0);
        rb2d.AddForce(movement * speed);
    }


    //--Jump and jump sound--//
    private void OnCollisionStay2D(Collision2D collision)
    { 
        if(collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

                //- Jump Sound-//
                AudioSource audio = GetComponent<AudioSource>();
                audio.PlayOneShot(jumpClip);
            }
        }
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

        //--goomba destroy?--//
        if (other.gameObject.CompareTag("Goomba"))
        {
            Destroy(gameObject);          
        }

        if (other.gameObject.CompareTag("End"))
        {
            other.gameObject.SetActive(true);
            SetWinText();
        }        
    }

    void SetCountText()
    {
     countText.text = "Count: " + count.ToString();
    }      

    void SetWinText()
    {
        winText.text = "You win";
    }
}
