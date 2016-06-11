using UnityEngine;
using System.Collections;

public class ObstacleCheck : MonoBehaviour {

    public Player player;

    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            player.onTouchObstacle();
        }
        
    }

}
