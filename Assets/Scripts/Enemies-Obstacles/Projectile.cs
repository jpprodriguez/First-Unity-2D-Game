using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float maxDistanceX;
    public float maxDistanceY;

    private Vector2 originalPos;
	// Use this for initialization
	void Start () {
        originalPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	    if(transform.position.x - originalPos.x > maxDistanceX || transform.position.y - originalPos.y > maxDistanceY)
        {
            Destroy(gameObject);
        }
	}
}
