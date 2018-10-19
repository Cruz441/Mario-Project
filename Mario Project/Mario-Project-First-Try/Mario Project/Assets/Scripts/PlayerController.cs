using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class PlayerController : MonoBehaviour {

    public float speed;    
    public AudioSource coinPickup;
    public Text countText;
    public int numofCoins;
    public float jumpForce;
    

    private Rigidbody2D rb2d;
    private int count;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        coinPickup = GetComponent<AudioSource>();
        count = 0;
        SetCountText();
        numofCoins = 5;
	}
	
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0);
        rb2d.AddForce(movement * speed);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            coinPickup.Play();
            count = count + 1;
            SetCountText();
        }       

        if (other.gameObject.CompareTag("CoinBox"))
        {
            other.gameObject.SetActive(true);
            coinPickup.Play();
            numofCoins = numofCoins - 1;
            if (numofCoins > 0)
            {
                count = count + 1;
                SetCountText();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Goomba")) 
        {
            count = count - 1;
            SetCountText();

        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }
}
