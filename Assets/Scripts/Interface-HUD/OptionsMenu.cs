using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsMenu : MonoBehaviour {

    public GameObject optionsUI;
    public Slider controlSlider;
	// Use this for initialization
	void Start () {
        dissapearMenu();
        controlSlider.value = GameData.getControlSize();
        controlSlider.onValueChanged.AddListener(delegate { controlSliderCheck(); });

    }

	public void controlSliderCheck()
    {
        GameData.setControlSize(Mathf.RoundToInt(controlSlider.value));
    }
    
    public void dissapearMenu()
    {
        transform.localScale = new Vector3(0, 0, 0);
    }
    public void appearMenu()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }
}
