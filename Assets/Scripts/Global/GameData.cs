using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameData : MonoBehaviour {

    private static int lifes;
    private static int score;
    private static int highScore;
    private static int maxScore;
    private static int coinScore = 50;
    private static int totalLevels;
	// Use this for initialization
	void Start () {
        AudioListener.volume = getVolume();
        totalLevels = getTotalLevels();
        lifes = PlayerPrefs.GetInt("Player Lifes", 3);
        if (lifes == 0)
        {
            setLifes(3);
        }
        highScore = PlayerPrefs.GetInt("HighScore",0);
        score = 0;
        
    }
	void Update()
    {
        if(score > highScore)
        {
            setHighScore(score);
        }
    }
    public static int getTotalLevels()
    {
        return totalLevels;
    }
    public static void setTotalLevels(int newLevels)
    {
        totalLevels = newLevels;
    }
    public static void setCoinScore(int score)
    {
        coinScore = score;
    }
    public static int getCoinScore()
    {
        return coinScore;
    }
    public static void setMaxScore(int newMaxScore)
    {
        maxScore = newMaxScore;
    }
    public static int getMaxScore()
    {
        return maxScore;
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
    }
    public static int getHighScore()
    {
        return highScore;
    }
    public static void setHighScore(int newScore)
    {
        highScore = newScore;
        PlayerPrefs.SetInt("HighScore", newScore);
    }

    public static void reloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public static bool isProfileLoaded()
    {
        if(PlayerPrefs.GetInt("isProfileLoaded", 0) == 0)
        {
            return false;
        }else
        {
            return true;
        }
    }
    public static void setProfileLoaded(bool value)
    {
        if(value == false)
        {
            PlayerPrefs.DeleteKey("isProfileLoaded");
        }else
        {
            PlayerPrefs.SetInt("isProfileLoaded", 1);
        }
    }
    public static int getLevel()
    {
        return PlayerPrefs.GetInt("Level", 1);
    }
    public static void SetLevel(int level)
    {
        PlayerPrefs.SetInt("Level", level);
    }

    public static void deleteAllPrefs()
    {
        PlayerPrefs.DeleteKey("Player Lifes") ;
        PlayerPrefs.DeleteKey("Level"); 
        PlayerPrefs.DeleteKey("isProfileLoaded");
    }
    public static void resetHighscore()
    {
        PlayerPrefs.DeleteKey("HighScore");
    }
    public static int getControlSize()
    {
        return PlayerPrefs.GetInt("ControlSize", 100);
    }
    public static void setControlSize(int size)
    {
        PlayerPrefs.SetInt("ControlSize", size);
    }
    public static float getVolume()
    {
        return PlayerPrefs.GetFloat("Volume",1f);
    }
    public static void setVolume(float volume)
    {
        PlayerPrefs.SetFloat("Volume", volume);
        
    }


}
