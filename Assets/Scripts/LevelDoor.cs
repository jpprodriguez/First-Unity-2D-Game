using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelDoor : MonoBehaviour {

    private Player player;
    public Text text;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	
    void OnTriggerEnter2D(Collider2D col)
    {
        player.onDoor = true;
        text.text = "GANASTE!!";
    }
    void OnTriggerExit2D(Collider2D col)
    {
        player.onDoor = false;
        text.text = "";
    }
}
