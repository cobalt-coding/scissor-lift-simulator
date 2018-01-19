using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour {
    
    public Rigidbody2D rb;
    public float force = 50;
    public float jumpForce = 500;
    private bool grounded = false;

	// Update is called once per frame
	void Update () {
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal")*force, 0)*Time.deltaTime);

        if (Input.GetKeyDown("space") && grounded == true)
        {
            rb.AddForce(new Vector2(0, jumpForce)*Time.deltaTime);
            Debug.Log("you pressed jump!");
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
           if (collision.gameObject.tag == "Ground")
            {
            grounded = true;
            }
      
       
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }


    }
}
