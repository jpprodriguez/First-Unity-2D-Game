using UnityEngine;
using System.Collections;

public class InitLevelData : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameData.setMaxScore(GameObject.FindGameObjectsWithTag("Coin").Length * GameData.getCoinScore());
	}
	
}
