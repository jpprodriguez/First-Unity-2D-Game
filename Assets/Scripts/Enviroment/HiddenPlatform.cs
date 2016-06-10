using UnityEngine;
using System.Collections;

public class HiddenPlatform : MonoBehaviour {

    public float velocity;
    public float minPos;
    public float maxPos;

    private bool startMoving;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb2d;
    // Use this for initialization
    void Start () {
        startMoving = false;
        spriteRenderer =GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (startMoving == true)
        {
            if (transform.position.x >= maxPos)
            {
                rb2d.velocity = new Vector2(-velocity, rb2d.velocity.y);
            }
            else if (transform.position.x <= minPos){
                rb2d.velocity = new Vector2(velocity, rb2d.velocity.y);
            }
        }
        
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (startMoving == false)
        {
            if (col.CompareTag("Player"))
            {
                spriteRenderer.enabled = true;
                startMoving = true;
                rb2d.velocity = new Vector2(velocity, rb2d.velocity.y);

            }
        }
        

    }
}
