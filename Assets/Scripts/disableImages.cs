using UnityEngine;
using System.Collections;

public class disableImages : MonoBehaviour {
    public SpriteRenderer sprender;
    // Use this for initialization
    void Start () {
        sprender = gameObject.GetComponent<SpriteRenderer>();
        sprender.enabled = false;
    }

}
