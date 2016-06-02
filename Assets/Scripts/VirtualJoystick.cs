using UnityEngine;
using System.Collections;

public class VirtualJoystick : MonoBehaviour {

    private int axis= 0;

    public int getAxis()
    {
        return axis;
    }

    public void leftButtonPressed()
    {
        axis = -1;
    }
    public void rightButtonPressed()
    {
        axis = 1;
    }
    public void leftButtonUp()
    {
        axis = 0;
    }
    public void rightButtonUp()
    {
        axis = 0;
    }
}
