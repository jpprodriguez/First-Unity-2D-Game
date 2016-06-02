using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    //Floats
    public float maxSpeed = 3f;
    public float speed = 150f;
    public float jumpPower = 300f;
    //Bool
    public bool grounded;
    public bool canDoubleJump;

    //References
    private Rigidbody2D rb2d;
    private Animator anim;
    

    // Use this for initialization
    void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
	}

    // Update is called once per frame
    
	void Update () {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));

        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
        float axis = canvas.GetComponent<VirtualJoystick>().getAxis();
        if (axis < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (axis > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

    }
    void FixedUpdate() {

        Vector3 easeVelocity = rb2d.velocity;
        easeVelocity.y = rb2d.velocity.y;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= 0.75f;

        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");

        float h = canvas.GetComponent<VirtualJoystick>().getAxis();

        //fake friction / easing the x of our player
        if (grounded)
        {
            rb2d.velocity = easeVelocity;
        }
        
        //Moving the Player
        rb2d.AddForce(Vector2.right * speed * h);
        Debug.Log("fuerza: " + (Vector2.right * speed * h));
        //Limiting the speed of the player
        if(rb2d.velocity.x > maxSpeed) {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }

        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }
        Debug.Log("velocity= " + rb2d.velocity);

    }

    public void jump()
    {
        if (grounded)
        {
            rb2d.AddForce(Vector2.up * jumpPower);
            canDoubleJump = true;
        }
        else
        {
            if (canDoubleJump == true)
            {
                canDoubleJump = false;
                rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                rb2d.AddForce(Vector2.up * jumpPower / 1.75f);
            }
        }
    }
        
}
