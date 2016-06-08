using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseUI;

    private bool paused = false;
    void Start()
    {
        pauseUI.SetActive(false);
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
            Time.timeScale = 1;
        }
    }

    public void mainMenuPressed()
    {
        //TODO
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
}
