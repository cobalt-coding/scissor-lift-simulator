using UnityEngine;

public class BasicWeapon : MonoBehaviour
{

    public float fireRate = 0; //Set the rate of fire. 0 means single shot
    public float damage = 10; // Set the damage it will do to the enemy
    public LayerMask whatToHit; //Put things that should be hit in this layer
    public Color bulletLineColorNull = Color.cyan; //Set what color you want the bullet line to be when it DOES NOT hit something
    public Color bulletLineColorValid = Color.red; //Set what color you want the bullet line to be when it DOES hit something

    float timeToFire = 0; //Used later
    public Transform firePoint; //Make an object of where you want to fire FROM and call it "Fire Point"

    // Use this for initialization
    void Awake()
    {
        firePoint = transform.Find("Fire Point"); //Find "Fire Point" and assign it to firePoint
        if (firePoint == null) //Null check
        {
            Debug.LogError("firePoint = null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (fireRate == 0) //If it is a single-shoot weapon...
        {
            if (Input.GetButtonDown("Fire1")) //...and the player is trying to shoot...
            {
                Shoot(); //...shoot.
            }
        }
        else if (Input.GetButton("Fire1") && Time.time > timeToFire) //Otherwise...
        {
            timeToFire = Time.time + 1 / fireRate; //...after the fireRate has passed...
            Shoot(); //...shoot.
        }
    }

    void Shoot()
    {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y); //Find mouse position
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y); //Make a Vector2 that holds the firePointPosition
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, (mousePosition - firePointPosition), 100, whatToHit); //Make a raycast from the firePoint to the mousePosition
        Debug.DrawLine(firePointPosition, (mousePosition - firePointPosition) * 100, bulletLineColorNull); //Draw a line where it shoots
        if (hit.collider != null) //If it hits something...
        {
            Debug.DrawLine(firePointPosition, hit.point, bulletLineColorValid); //...make a line from the firePoint to what it hit...
            Debug.Log("Hit: " + hit.collider.name + ". Damage: " + damage); //...and write info about it in Debug.Log(Change this to actually do damage later)
        }
    }
}