using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour {
    
    public float force = 50;
    public float jumpForce = 500;
    public float speedLimit = 7;

    public Rigidbody2D rb;
    public SpriteRenderer sr;

    public float health = 100;
    private bool grounded = false;

	// Update is called once per frame
	void Update () {
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal")*force, 0)*Time.deltaTime);

        if (Input.GetKeyDown("space") && grounded == true)
        {
            rb.AddForce(new Vector2(0, jumpForce)*Time.deltaTime);
        }

        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -speedLimit, speedLimit), rb.velocity.y);
        Debug.Log(rb.velocity.x);

        robotFlip();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Ground":
                grounded = true;
                break;
            case "DamagingBoy":
                health-=10;
                break;
            default:
                grounded = true;
                break;
                
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Ground":
                grounded = false;
                break;
            default:
                grounded = false;
                break;
        }
    }

    private void robotFlip()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            sr.flipX = false;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            sr.flipX = true;
        }
    }

}
