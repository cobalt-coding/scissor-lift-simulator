using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RobotController : MonoBehaviour {

    public GameObject DeathScreenBkgd;
    public GameObject corpse;
    public Vector3 spawnpoint;

    public float force = 50;
    public float jumpForce = 500;
    public float speedLimit = 7;
    public float fallMultiplier = 4f;
    public float lowJumpMultiplier = 5f;

    public Rigidbody2D rb;
    public SpriteRenderer sr;

    public float health = 100;
    private bool grounded = false;

    public bool createdBkgd = false;

    void Start()
    {
        spawnpoint = transform.position;
    }

    // Update is called once per frame
    void Update () {
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal")*force, 0)*Time.deltaTime);

        if (Input.GetKeyDown("space") && grounded == true)
        {
            rb.AddForce(new Vector2(0, jumpForce)*Time.deltaTime);
        }
        
        if(rb.velocity.y < -0.01f)
        {
            rb.velocity -= (Vector2.up * fallMultiplier * Time.deltaTime * 10);
        } else if (rb.velocity.y > 0.01f && !Input.GetKey("space")) {
            rb.velocity -= (Vector2.up * lowJumpMultiplier * Time.deltaTime * 10);
        }
        

        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -speedLimit, speedLimit), rb.velocity.y);

        RobotFlip();
        if(health <= 0)
        {
            Death();
        }

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
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Ground":
                grounded = false;
                break;
        }
    }

    private void RobotFlip()
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

    private void Death()
    {
        if (!createdBkgd) //Death
        {
            Instantiate(DeathScreenBkgd, transform);
            createdBkgd = true;
            Instantiate(corpse, transform);
        }

        if(Input.GetKeyDown("r")) //Restarting the level
        {
            health = 100;
            createdBkgd = false;
            Destroy(GameObject.FindWithTag("Respawn"));
            transform.position = spawnpoint;
            

        }
    }

}
