using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goomba : MonoBehaviour {

    public float moveSpeed;
    public Text loseText;

    void Start()
    {
        loseText.text = "";
    }

    void Update () {
        transform.Translate(new Vector3(moveSpeed, 0, 0) * Time.deltaTime);
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            moveSpeed *= -1;
        }
        
        if(collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            loseText.text = "Game Over";
        }
    }    
}
