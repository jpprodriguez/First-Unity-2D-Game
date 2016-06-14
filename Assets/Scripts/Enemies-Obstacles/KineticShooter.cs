using UnityEngine;
using System.Collections;

public class KineticShooter : MonoBehaviour {

    public float maxSpeed;
    public float speed;
    public float shootingRange;
    public float minX;
    public float maxX;

    //References
    private Rigidbody2D rb2d;
    private Animator anim;
    public Player player;
    public GameObject bulletPrefab;
    private int timer;

    //Estados
    private static string[] states = new string[3] { "idle", "follow player", "shoot" };
    private string currentState = states[0];


    // Use this for initialization
    void Start()
    {
        timer = 0;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer--;
        }
        if (player.transform.position.x >= transform.position.x + 0.5f && player.transform.position.x <= transform.position.x - 0.5f)
        {
            //TODO
            Debug.Log("funciona");
        }
        if(Mathf.Abs(player.transform.position.x - transform.position.x) <= shootingRange)
        {
            currentState = states[2];
            anim.SetBool("ableToShoot", true);
        }
        else if (player.transform.position.x > minX && player.transform.position.x < maxX)
        {
            currentState = states[1];
            anim.SetBool("ableToShoot", false);
        }
        else
        {
            currentState = states[0];
            anim.SetBool("ableToShoot", false);
        }

    }
    void FixedUpdate()
    {
        switch (currentState)
        {
            case "idle":
                walk();
                break;
            case "follow player":
                followPlayer();
                break;
            case "shoot":
                shoot();
                break;
        }
    }
    private void shoot()
    {

        rb2d.velocity = Vector2.zero;
        if (player.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (timer == 0)
        {
           
            GameObject bullet = (GameObject)Instantiate(bulletPrefab, new Vector3(transform.position.x + 0.35f ,transform.position.y,transform.position.z), Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x * 2.5f, 0);
            bullet.GetComponent<ObstacleCheck>().player = player;
            bullet.GetComponent<Projectile>().maxDistanceX = 5;
            bullet.GetComponent<Projectile>().maxDistanceY = 0;
            timer = 60;

        }
        
    }
    private void walk()
    {
        if (transform.position.x <= minX + 1)
        {
            transform.localScale = new Vector3(-1, 1, 1);

        }
        else if (transform.position.x >= maxX - 1)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        Vector2 vec = transform.localScale;
        vec.x *= -1;
        vec.y = 0;

        rb2d.AddForce(vec * speed);


        //Limiting the speed of the dog
        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }

        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }
    }
    private void followPlayer()
    {

        float newSpeed = speed + 20;
        float newMaxSpeed = maxSpeed + 1;

        if (player.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
            rb2d.AddForce(Vector2.right * newSpeed);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
            rb2d.AddForce(Vector2.left * newSpeed);
        }

        //Limiting the speed of the dog
        if (rb2d.velocity.x > newMaxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }

        if (rb2d.velocity.x < -newMaxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }
    }
}
