using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsMenu : MonoBehaviour {

    public GameObject optionsUI;
    public Slider controlSlider;
    public Slider volumeSlider;
	// Use this for initialization
	void Start () {
        dissapearMenu();
        controlSlider.value = GameData.getControlSize();
        controlSlider.onValueChanged.AddListener(delegate { controlSliderCheck(); });

        volumeSlider.value = GameData.getVolume();
        volumeSlider.onValueChanged.AddListener(delegate { volumeSliderCheck(); });

    }

	public void controlSliderCheck()
    {
        GameData.setControlSize(Mathf.RoundToInt(controlSlider.value));
    }
    public void volumeSliderCheck()
    {
        AudioListener.volume = volumeSlider.normalizedValue;
        GameData.setVolume(volumeSlider.normalizedValue);
    }
    
    public void dissapearMenu()
    {
        transform.localScale = new Vector3(0, 0, 0);
    }
    public void appearMenu()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }
    public void resetHighscore()
    {
        GameData.resetHighscore();
    }
}
