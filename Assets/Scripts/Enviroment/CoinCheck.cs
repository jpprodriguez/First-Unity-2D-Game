using UnityEngine;
using System.Collections;

public class CoinCheck : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            GetComponent<PlaySound>().playSound(false);
            GameData.setScore(GameData.getScore() + GameData.getCoinScore());
            Destroy(gameObject);
        }

    }
}
