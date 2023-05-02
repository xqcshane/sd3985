using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MouseControl
{
  
    // Start is called before the first frame update
 
    public static Vector3 GetMouseWorldPosition()
    {

        Vector3 vec = GetMousePositionZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }
    //get the mouse world position 
    public static Vector3 GetMousePositionZ(Vector3 screenPosition, Camera worldcamera)
    {
        Vector3 worldPosition= worldcamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }
    // Update is called once per frame

}
