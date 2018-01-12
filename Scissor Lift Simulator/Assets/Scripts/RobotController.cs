using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour {
    
    public Rigidbody2D rb;
    public float force = 50;
    public float jumpForce = 500;

	// Update is called once per frame
	void Update () {
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal")*force, 0)*Time.deltaTime);

        if (Input.GetKeyDown("space"))
        {
            rb.AddForce(new Vector2(0, jumpForce)*Time.deltaTime);
            Debug.Log("you pressed jump!");
        }
	}
}
