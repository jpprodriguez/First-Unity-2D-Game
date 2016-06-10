using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseUI;
    public GameObject optionsUI;
    private bool paused = false;
    void Start()
    {
        paused = false;
        dissapearMenu();
    }
    public void dissapearMenu()
    {
        transform.localScale = new Vector3(0, 0, 0);
    }
    public void appearMenu()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }
    public void pauseButtonPressed()
    {
        paused = !paused;

        if (paused)
        {
            appearMenu();
            Time.timeScale = 0;
        }
        else
        {
            dissapearMenu();
            optionsUI.GetComponent<OptionsMenu>().dissapearMenu();
            Time.timeScale = 1;
        }
    }

    public void mainMenuPressed()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(LevelToScene.levelToSceneName(0));
    }

    public void restartPressed()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void quitPressed()
    {
        Application.Quit();
    }
    public void optionsPressed()
    {
        openOptionsMenu();
    }
    public void openOptionsMenu()
    {
        dissapearMenu();
        optionsUI.GetComponent<OptionsMenu>().appearMenu();
    }
    public void closeOptionsMenu()
    {
        optionsUI.GetComponent<OptionsMenu>().dissapearMenu();
        appearMenu();

    }
}
