using UnityEngine;
using System.Collections;

public class FadeCanvas : MonoBehaviour {

    public CanvasGroup canvas;
	// Use this for initialization
    public void fadeCanvas()
    {
        StartCoroutine(doFade()) ;
    }
    private IEnumerator doFade()
    {
        while(canvas.alpha > 0)
        {
            canvas.alpha -= Time.deltaTime / 2;
            yield return 0;
        }
    }
}
