using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour {

    public float velocity;
    public float fallDistance;

    private bool startMoving;
    private Rigidbody2D rb2d;
    private float startPos;
    // Use this for initialization
    void Start()
    {
        startMoving = false;
        rb2d = GetComponent<Rigidbody2D>();
        startPos = transform.position.y;
    }
	
    void Update()
    {
        if(Mathf.Abs(transform.position.y - startPos) >= fallDistance)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (startMoving == false)
        {
            if (col.CompareTag("Player"))
            {
                startMoving = true;

                StartCoroutine(turnOffKinematic());
            }
        }


    }
    private IEnumerator turnOffKinematic()
    {
        yield return new WaitForSeconds(0.5f);
        rb2d.isKinematic = false;
    }
}
