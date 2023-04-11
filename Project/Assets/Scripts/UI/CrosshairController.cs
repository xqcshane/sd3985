using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairController : MonoBehaviour
{
    // Start is called before the first frame update
    //find the crosshair and set it position to the mouse in real screen position
    private Transform crosshairpos;
    public Vector3 screenPosition;
    public Vector3 worldPosition;
    void Start()
    {
        crosshairpos = GameObject.Find("crosshair").transform;
    }

    // Update is called once per frame
    void Update()
    {
        screenPosition=Input.mousePosition;
        //allow the crosshair to be seen by the camera to let it topper than the nearclip
        screenPosition.z = Camera.main.nearClipPlane + 1;
        worldPosition=Camera.main.ScreenToWorldPoint(screenPosition);
        crosshairpos.position = worldPosition;
    }
}
