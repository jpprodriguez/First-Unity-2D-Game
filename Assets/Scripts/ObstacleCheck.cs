using UnityEngine;
using System.Collections;

public class ObstacleCheck : MonoBehaviour {

    private Player player;
    public float time = 0.02f;
    public float pwrX = 100;
    public float pwrY = 350;
    //public float posX;
    //public float posY;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            player.onTouchObstacle();
        }
        
    }
    /*
    void OnTriggerEnter2D(Collider2D col)
    {
        player.Damage(1);
        player.onTouchObstacle(posX, posY);
    }
    */

}
