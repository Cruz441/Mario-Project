using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinBox : MonoBehaviour
{

    private bool hittingCoinBox;
    private Rigidbody2D rb;

    public Transform bottomCoinBox;
    public LayerMask coinBox;
    public float checkRadius;

    public AudioClip coinPickup;

    public Text countText;
    private int count;

    // Use this for initialization
    void Start()
    {
        count = 0;
        countText.text = "";
        SetCountText();
    }

    // Update is called once per frame
    void Update()
    {
        hittingCoinBox = Physics2D.OverlapCircle(bottomCoinBox.position, checkRadius, coinBox);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && hittingCoinBox == true)
        {
            count = count + 1;
            SetCountText();

            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(coinPickup);
        }

    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }
}