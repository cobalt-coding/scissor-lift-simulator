using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageBoyAI : MonoBehaviour {
    public Rigidbody2D rb;
    public Transform player;
    public Transform rageBoi;
    public float force = 2000;
    private bool grounded = false;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerLocation = player.transform.position;
        Vector3 rageBoiLocation = rageBoi.transform.position;

        if (playerLocation.x > rageBoiLocation.x)
            rb.AddForce(new Vector2(force, 0) * Time.deltaTime);
        else
            rb.AddForce(new Vector2(-force, 0) * Time.deltaTime);
        
        if (playerLocation.y > rageBoiLocation.y && grounded == true)
                rb.AddForce(new Vector2(0, force) * Time.deltaTime);
          
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ground":
                grounded = true;
                break;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ground":
                grounded = false;
                break;
        }
    }
}
