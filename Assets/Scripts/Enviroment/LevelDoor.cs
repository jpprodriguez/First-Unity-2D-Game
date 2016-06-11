using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelDoor : MonoBehaviour {

    public Player player;
    public Text text;
    public Material material1;
    public Material material2;
    private SpriteRenderer sprite;
    // Use this for initialization
    void Start () {
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }
	
    void OnTriggerEnter2D(Collider2D col)
    {
        player.onDoor = true;
        
        sprite.material = material1;
        text.text = "GANASTE!!";
    }
    void OnTriggerExit2D(Collider2D col)
    {
        player.onDoor = false;
        sprite.material = material2;
        text.text = "";
    }
}
