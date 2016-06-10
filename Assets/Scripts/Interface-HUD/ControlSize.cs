using UnityEngine;
using System.Collections;

public class ControlSize : MonoBehaviour {

    public GameObject optionsMenu;
    public GameObject Pad;
    public GameObject jumpButton;

    private Vector2 maxPadSize;
    private Vector2 maxJumpButtonSize;
    private int controlSize;
	// Use this for initialization
    void Awake()
    {
        maxPadSize = Pad.transform.localScale;
        maxJumpButtonSize = jumpButton.transform.localScale;
    }
	void Start () {
        controlSize = GameData.getControlSize();
        Pad.transform.localScale = new Vector2(maxPadSize.x * controlSize / 100, maxPadSize.y * controlSize / 100);
        jumpButton.transform.localScale = new Vector2(maxJumpButtonSize.x * controlSize / 100, maxJumpButtonSize.y * controlSize / 100);
    }
	
	// Update is called once per frame
	void Update () {
        if(optionsMenu.transform.localScale == new Vector3(1, 1, 1))
        {
            controlSize = GameData.getControlSize();
            Pad.transform.localScale = new Vector2(maxPadSize.x * controlSize / 100, maxPadSize.y * controlSize / 100);
            jumpButton.transform.localScale = new Vector2(maxJumpButtonSize.x * controlSize / 100, maxJumpButtonSize.y * controlSize / 100);
        }
            
        
        
    }
}
