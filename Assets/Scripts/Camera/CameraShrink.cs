using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CameraShrink : MonoBehaviour {

    private Camera Camera;
    public GameObject canvas;
    private bool shrinkEnabled = false;
	// Use this for initialization
	void Start () {
        Camera = GetComponent<Camera>();
    }
	
	public void shrinkCamera()
    {
        canvas.SetActive(false);
        shrinkEnabled = true;
 
    }
    void Update()
    {
        if (shrinkEnabled)
        {
            Camera.orthographicSize -= 0.1f;
            if(Camera.orthographicSize <= 1)
            {
                shrinkEnabled = false;
                SceneManager.LoadScene("LevelComplete");
                
            }
        }
    }
}
