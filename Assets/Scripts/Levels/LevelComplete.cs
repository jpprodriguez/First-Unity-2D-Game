using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour {

    [SerializeField]
    private Text pressToContinue;
    [SerializeField]
    private Text maxScore;
    [SerializeField]
    private Text totalScore;
    [SerializeField]
    private Text percentage;
    [SerializeField]
    private Text level;
    private string sceneName;
    // Use this for initialization
    void Start () {
        //Obtengo nombre de nivel
        Debug.Log(GameData.getLevel());
        sceneName = LevelToScene.levelToSceneName(GameData.getLevel());
        string[] nameSplitted = sceneName.Split('-');
        sceneName = "Stage " + nameSplitted[0] + " - " + "Level " + nameSplitted[1];
        level.text = sceneName;

        //Obtengo maxScore
        maxScore.text = GameData.getMaxScore().ToString();

        //Obtengo totalScore
        totalScore.text = GameData.getScore().ToString();

        //Calculo percentage
        if (GameData.getMaxScore() > 0)
        {
            percentage.text = (GameData.getScore() * 100 / GameData.getMaxScore()).ToString() + "%";
        }
        else percentage.text = "0%";
        

       


    }
    void Update()
    {
        //Hago que titile el pressToContinue
        pressToContinue.color = new Color(pressToContinue.color.r, pressToContinue.color.g, pressToContinue.color.b, Mathf.PingPong(Time.time, 1));
    }

    public void onContinuePressed()
    {
        GameData.setScore(0);
        if(GameData.getLevel() == GameData.getTotalLevels())
        {
            //TODO
            Debug.Log("TODO");
        }else
        {
            GameData.SetLevel(GameData.getLevel() + 1);
            SceneManager.LoadScene("LevelLoad");
        }
        
    }
	
}
