using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class IndexMenu : MonoBehaviour {

    public GameObject pauseUI;
    public GameObject optionsUI;

    public Transform loadGameButton;
    // Use this for initialization
    void Start () {
        if (GameData.isProfileLoaded() == false)
        {
            loadGameButton.GetComponent<Button>().interactable = false;
        }
	}
	
	public void loadGamePressed()
    {
        SceneManager.LoadScene("LevelLoad");
    }
    public void newGamePressed()
    {
        GameData.deleteAllPrefs();
        GameData.setProfileLoaded(true);
        GameData.SetLevel(1);
        SceneManager.LoadScene("LevelLoad");
    }
    public void quitPressed()
    {
        Application.Quit();
    }
    public void optionsPressed()
    {
        openOptionsMenu();
    }
    
    private void openOptionsMenu()
    {
        optionsUI.GetComponent<OptionsMenu>().appearMenu();
        dissapearMenu();
    }
    public void closeOptionsMenu()
    {
        optionsUI.GetComponent<OptionsMenu>().dissapearMenu();
        appearMenu();

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
