using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HUD : MonoBehaviour {

    public Sprite[] HeartSprites;
    public Image HeartUI;

	// Update is called once per frame
	void Update () {
        HeartUI.sprite = HeartSprites[GameData.getLifes()];
	}
}
