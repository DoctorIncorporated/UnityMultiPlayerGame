using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    private void FixedUpdate(){
        transform.Rotate(0, 0, -Input.GetAxis("Horizontal") * 100f * Time.deltaTime);

        if (Input.GetAxis("Vertical") > 0 || Input.GetAxis("Horizontal") != 0)
        {
            Network.Move(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            rb2d.AddForce(transform.up * 5f * Input.GetAxis("Vertical"));
            //Network.Move(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
        }
        else
        {
            rb2d.velocity = Vector2.zero;
        }
    }
}
