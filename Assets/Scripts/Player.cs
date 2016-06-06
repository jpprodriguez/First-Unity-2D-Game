using CnControls;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour {

    //Int
    public int lifes = 3;
    //Floats
    public float maxSpeed = 3f;
    public float speed = 100f;
    public float jumpPower = 300f;
    //Bool
    public bool grounded;
    private bool crouched;
    public bool canDoubleJump;
    public bool onDoor;

    //References
    private Rigidbody2D rb2d;
    private Animator anim;

    private bool movementEnabled;
    

    // Use this for initialization
    void Start () {
        
        lifes = PlayerPrefs.GetInt("Player Lifes",3);
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        enableMovement();


    }

    // Update is called once per frame
    
	void Update () {
        if(movementEnabled == false)
        {
            return;
        }
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("Crouched", crouched);
        anim.SetBool("onDoor", onDoor);
        if(Input.GetButtonUp("Jump"))
        {
            jump();
        }
        if (CnInputManager.GetAxis("Vertical") < 0)
        {
            crouched = true;
        }else
        {
            crouched = false;
        }
        if (CnInputManager.GetAxis("Horizontal")<0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (CnInputManager.GetAxis("Horizontal") > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if(transform.position.y < -2)
        {
            Damage(1);
        }
        

    }
    void FixedUpdate() {
        if (movementEnabled == false)
        {
            return;
        }
        float h = CnInputManager.GetAxis("Horizontal");
        
        //fake friction / easing the x of our player
        if (crouched == false)
        {
            rb2d.AddForce(Vector2.right * speed * h);
        }

        //Limiting the speed of the player
        if (rb2d.velocity.x > maxSpeed) {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }

        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }

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
    public void Damage(int damage)
    {
        
        if (damage > lifes || damage == lifes)
        {
            lifes = 0;
            PlayerPrefs.SetInt("Player Lifes", 3);
            
        }
        else
        {
            lifes -= damage;
            PlayerPrefs.SetInt("Player Lifes", lifes);
        }
        Die();

    }
    public void Die()
    {
        disableMovement();
        anim.Play("Player_Die");
        StartCoroutine(ReloadSceneAfterDieAnimation());

    }
    private void disableMovement()
    {
        rb2d.velocity = Vector3.zero;
        rb2d.isKinematic = true;
        movementEnabled = false;
    }
    private void enableMovement()
    {
        rb2d.isKinematic = false;
        movementEnabled = true;
    }
    public IEnumerator Knockback(float knockbackDur, float knockbackPwrX, float knockbackPwrY)
    {
        if(transform.localScale.x == 1)
        {
            knockbackPwrX *= -1;
        }
        

        float timer = 0;

        while(knockbackDur > timer)
        {
            timer += Time.deltaTime;
            rb2d.velocity = Vector3.zero;
            rb2d.AddForce(new Vector2(knockbackPwrX, knockbackPwrY));
        }
        yield return 0;
    }
    
    public void onTouchObstacle()
    {
        Damage(1);
        
    }
    private IEnumerator ReloadSceneAfterDieAnimation()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
