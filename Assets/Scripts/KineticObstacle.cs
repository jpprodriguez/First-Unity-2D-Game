using UnityEngine;
using System.Collections;

public class KineticObstacle : MonoBehaviour {
    public float startPosition;
    public float endPosition;
    private int direction =1;
	// Use this for initialization
	void Start () {
        transform.position = new Vector3(transform.position.x, startPosition, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
        float actualPosition = transform.position.y;
	    if(actualPosition >= endPosition)
        {
            direction = -1;

        }else if(actualPosition <= startPosition)
        {
            direction = 1;
        }

        if(direction == 1)
        {
            transform.position = new Vector3(transform.position.x, actualPosition += (Time.deltaTime *10), transform.position.z);
        }else
        {
            transform.position = new Vector3(transform.position.x, actualPosition -= (Time.deltaTime), transform.position.z);
        }
	}
}
