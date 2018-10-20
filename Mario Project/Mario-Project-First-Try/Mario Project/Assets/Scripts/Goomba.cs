using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goomba : MonoBehaviour {

    public float moveSpeed;
    public Text loseText;
    public Transform goombaHead;

    //-goomba kill variables--//
    public AudioClip marioDied;


    public Transform headCheck;

    void Start()
    {
        loseText.text = "";
    }


    //--Goomba movement--//
    void Update () {
        transform.Translate(new Vector3(moveSpeed, 0, 0) * Time.deltaTime);   
    }

    //--if goomba hits wall turn around--//
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            moveSpeed *= -1;
        }
        
        //--if goomba hits player kill player--//
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.SetActive(false);
            loseText.text = "Game Over";
           
        }      
    }  
}
