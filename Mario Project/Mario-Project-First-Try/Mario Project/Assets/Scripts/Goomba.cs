using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba : MonoBehaviour {

    public float moveSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(moveSpeed, 0, 0) * Time.deltaTime);
	}

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Wall")
        {
            moveSpeed *= -1;
        }
    }
}
