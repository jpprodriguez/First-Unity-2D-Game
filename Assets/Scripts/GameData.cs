using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameData : MonoBehaviour {

    private static int lifes;
    private static int score;
    private static int highScore;
    private static int level;
	// Use this for initialization
	void Start () {
        lifes = PlayerPrefs.GetInt("Player Lifes", 3);
        if (lifes == 0)
        {
            setLifes(3);
        }
        score = PlayerPrefs.GetInt("Score", 0);
        score = PlayerPrefs.GetInt("HighScore", 0);
    }
	void Update()
    {
        if(score > highScore)
        {
            setHighScore(score);
        }
    }
    public static void setLifes(int newLifes)
    {
        lifes = newLifes;
        PlayerPrefs.SetInt("Player Lifes", newLifes);
        
    }
    public static int getLifes()
    {
        return lifes;
    }
    public static int getScore()
    {
        return score;
    }
    public static void setScore(int newScore)
    {
        score = newScore;
        PlayerPrefs.SetInt("Score", newScore);
    }
    public static int getHighScore()
    {
        return highScore;
    }
    public static void setHighScore(int newScore)
    {
        highScore = newScore;
        PlayerPrefs.SetInt("Highscore", newScore);
    }

    public static void reloadLevel()
    {
        setScore(0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
