using UnityEngine;
using System.Collections;

public class ObstacleCheck : MonoBehaviour {

    private Player player;
    //public float time = 0.02f;
    //public float pwrX = 100;
    //public float pwrY = 350;
    public float posX;
    public float posY;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    /*
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            player.Damage(1);
            StartCoroutine(player.Knockback(time, pwrX, pwrY));
        }
        
    }
    */
    void OnTriggerEnter2D(Collider2D col)
    {
        player.onTouchObstacle(posX, posY);
    }

}
