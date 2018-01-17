using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRobotController : MonoBehaviour {

    public Transform transform;
    public float speedMultiplier = 1.0f;
    public float jumpHeight = 8.0f;
    public float gravity = 0.3f;
    public float slowDownSpeed = 1.1f;

    private float x;
    private float y;
    private float velX;
    private float velY;
    private bool isFalling;

    private bool isCollidingWithGround = false;

    private void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
        isFalling = true;
    }

    // Update is called once per frame
    void Update()
    {

        velX += Input.GetAxis("Horizontal")*speedMultiplier;

        if (Input.GetButtonDown("Jump")/* && !isFalling*/)
        {
            velY -= jumpHeight;
        }
        isFalling = true;

        //velY -= gravity;

        x += velX;
        if (isCollidingWithGround)
        {
            collide(velX, 0.0f);
        }
        y += velY;
        if (isCollidingWithGround)
        {
            collide(0.0f, velY);
        }

        velX /= slowDownSpeed;

        transform.position = new Vector2(x, y)*Time.deltaTime;
    }

    private void collide(float velocityX, float velocityY)
    {
        //if (velocityX > 0 || velocityX < 0)
       // {
        //    velX = 0.0f;
        //}
        if (velocityY > 0)
        {
            velY = 0.0f;
            isFalling = false;
        }
        if (velocityY < 0)
        {
            velY = 0.0f;
            isFalling = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isCollidingWithGround = collision.gameObject.tag == "Ground" ? true : false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (isCollidingWithGround)
        {
            isCollidingWithGround = false;
        }
    }

}
