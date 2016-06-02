using UnityEngine;
using System.Collections;

public class VirtualJoystick : MonoBehaviour {

    private float axis= 0;
    private int moveDir = 0;

    public float getAxis()
    {
        return axis;
    }
    public int getMoveDir()
    {
        return moveDir;
    }
    void Update()
    {
        if(moveDir == -1)
        {
            if (axis > -1)
            {
                axis -= 0.05f;
            }
            else
            {
                axis = -1;
            }

        }else if(moveDir == 1)
        {
            if (axis < 1)
            {
                axis += 0.05f;
            }
            else
            {
                axis = 1;
            }
        }
    }
    public void leftButtonPressed()
    {
        moveDir = -1;
    }
    public void rightButtonPressed()
    {
        moveDir = 1;
    }
    public void leftButtonUp()
    {
        moveDir = 0;
        axis = 0;
    }
    public void rightButtonUp()
    {
        moveDir = 0;
        axis = 0;
    }
}
