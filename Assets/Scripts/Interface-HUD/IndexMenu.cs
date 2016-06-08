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
        SceneManager.LoadScene(LevelToScene.levelToSceneName(GameData.getLevel()));
    }
    public void newGamePressed()
    {
        GameData.deleteAllPrefs();
        GameData.setProfileLoaded(true);
        SceneManager.LoadScene(LevelToScene.levelToSceneName(1));
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
        pauseUI.SetActive(false);
        optionsUI.SetActive(true);
    }

}
