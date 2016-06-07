using UnityEngine;
using System.Collections;

public class CoinCheck : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            GameData.setScore(GameData.getScore() + 50);
            Destroy(gameObject);
        }

    }
}
