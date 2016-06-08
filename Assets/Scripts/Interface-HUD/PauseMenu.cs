using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseUI;
    public GameObject optionsUI;
    private bool paused = false;
    void Start()
    {
        pauseUI.SetActive(false);
        optionsUI.SetActive(false);
    }

    public void pauseButtonPressed()
    {
        paused = !paused;

        if (paused)
        {
            pauseUI.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pauseUI.SetActive(false);
            optionsUI.SetActive(false);
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
        pauseUI.SetActive(false);
        optionsUI.SetActive(true);
    }
}
