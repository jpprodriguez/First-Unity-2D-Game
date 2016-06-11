using UnityEngine;
using System.Collections;

public class LevelToScene : MonoBehaviour {

    public static string[] levels = {"Index","A-1"};
	
    public static string levelToSceneName(int level)
    {
        return levels[level];
    }
}
