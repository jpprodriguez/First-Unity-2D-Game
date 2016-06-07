using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HUD : MonoBehaviour {

    public Sprite[] HeartSprites;
    public Image HeartUI;
    public Text Score;
    public Text HighScore;

	// Update is called once per frame
	void Update () {
        HeartUI.sprite = HeartSprites[GameData.getLifes()];
        Score.text = GameData.getScore().ToString();
        HighScore.text = GameData.getHighScore().ToString();
    }
}
