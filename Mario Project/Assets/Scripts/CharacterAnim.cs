using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnim : MonoBehaviour {

    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("isRunningRight", true);
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("isRunningLeft", true);
        }
        else
        {
            anim.SetBool("isRunningRight", false);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.SetTrigger("isJumping");
        }
	}
}
