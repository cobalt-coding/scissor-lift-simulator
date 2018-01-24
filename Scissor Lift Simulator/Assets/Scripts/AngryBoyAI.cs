using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryBoyAI : MonoBehaviour {

    public Rigidbody2D rb;
    public bool right = true;
    public float force = 2000;
    int delay;

    // Use this for initialization
    void Start() {
        new Vector2(force, 0);
    }
	
	// Update is called once per frame
	void Update () {
        if (right) 
            rb.AddForce(new Vector2(force, 0) * Time.deltaTime);
        else
            rb.AddForce(new Vector2(-force, 0) * Time.deltaTime);

        
        if (Math.Abs(rb.velocity.x) < 1 && Time.frameCount - delay > 10)
        {
            right = !right;
            delay = Time.frameCount;
        }
	}
}
