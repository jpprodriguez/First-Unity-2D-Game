using UnityEngine;
using System.Collections;

public class jump : MonoBehaviour {

    bool jumpActive = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (jumpActive == true)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<Player>().jump();
            jumpActive = false;
        }
	}

    public void isJumpActive()
    {
        jumpActive = true;
    }
}
