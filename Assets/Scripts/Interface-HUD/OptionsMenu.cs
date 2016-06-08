using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsMenu : MonoBehaviour {

    public GameObject menu;
    public GameObject optionsUI;
    public Slider controlSlider;
	// Use this for initialization
	void Start () {
        optionsUI.SetActive(false);
        controlSlider.value = GameData.getControlSize();
        controlSlider.onValueChanged.AddListener(delegate { controlSliderCheck(); });

    }

	public void controlSliderCheck()
    {
        GameData.setControlSize(Mathf.RoundToInt(controlSlider.value));
    }
    public void backPressed()
    {
        closeOptionsMenu();
    }
    private void closeOptionsMenu()
    {
        optionsUI.SetActive(false);
        menu.SetActive(true);

    }
}
