using System;
using UnityEngine;
using UnityEngine.UI;

public class AngryBoyAI : MonoBehaviour {

    public GameObject actualText;
    public Rigidbody2D rb;
    public bool right = true;
    public float force = 2000;
    int delay;
    public int health = 100;

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

        
        if (Math.Abs(rb.velocity.x) <= 0 && Time.frameCount - delay > 10)
        {
            right = !right;
            delay = Time.frameCount;
        }

        //actualText.GetComponent<RectTransform>().position = transform.position;
        actualText.GetComponent<Text>().text = "Enemy Health: " + health;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

}
