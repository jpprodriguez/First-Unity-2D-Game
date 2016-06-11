using UnityEngine;
using System.Collections;

public class Dog : MonoBehaviour {

    public float maxSpeed;
    public float speed;
    public float minX;
    public float maxX;

    //References
    private Rigidbody2D rb2d;
    private Animator anim;
    public Player player;

    //Estados
    private static string[] states = new string[2] { "idle", "follow player" };
    private string currentState = states[0];


    // Use this for initialization
    void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (player.transform.position.x >= transform.position.x + 0.5f && player.transform.position.x <= transform.position.x - 0.5f)
        {
            //TODO
            Debug.Log("funciona");
        }
	    if(player.transform.position.x > minX && player.transform.position.x < maxX)
        {
            currentState = states[1];
            anim.SetBool("walking", false);
        }else
        {
            currentState = states[0];
            anim.SetBool("walking", true);
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

        if(player.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            rb2d.AddForce(Vector2.right * newSpeed);
        }else
        {
            transform.localScale = new Vector3(1, 1, 1);
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
