using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
//using CodeMonkey.Utils;

public class PointerToItems : MonoBehaviour
{
    [SerializeField]
    public Camera uiCamera;
    [SerializeField]
    private Sprite arrowSprite;
    [SerializeField]
    private Sprite crossSprite;
    
    private Vector3 targetPosition;
    private RectTransform PointerRectTransform;
    private Image pointerImage;

    public GameObject MyFindItem;
    public float ImageOrignalRoutate;
    
    //change the border size
    private float bordersize = 100f;

    private void Start(){        
        targetPosition = MyFindItem.transform.position;
        PointerRectTransform = transform.Find("Pointer").GetComponent<RectTransform>();
        pointerImage = transform.Find("Pointer").GetComponent<Image>();
    }
    
    public static float GetAngle(Vector2 a, Vector2 b)
    {
        double x = b.x - a.x;
        double y = b.y - a.y;
        return (float)(Math.Atan2(y, x) * (180 / Math.PI));
    }

    private void Update(){
        Vector3 toPosition = MyFindItem.transform.position;
        Vector3 fromPosition =  Camera.main.transform.position;
        fromPosition.z = 0f;
        Vector3 dir = (toPosition - fromPosition).normalized;
        float angle = GetAngle(fromPosition, toPosition) + ImageOrignalRoutate;      

        PointerRectTransform.localEulerAngles = new Vector3(0,0,angle);

        Vector3 targetPositionScreenPoint = Camera.main.WorldToScreenPoint(targetPosition);
        bool isOffScreen = targetPositionScreenPoint.x <= bordersize || targetPositionScreenPoint.x >= Screen.width-bordersize || targetPositionScreenPoint.y <= bordersize || targetPositionScreenPoint.y >= Screen.height - bordersize;
        if (isOffScreen){
            pointerImage.sprite = arrowSprite;
            Vector3 cappedtargetPositionScreen = targetPositionScreenPoint;
            if(cappedtargetPositionScreen.x <= bordersize)cappedtargetPositionScreen.x=bordersize;
            if(cappedtargetPositionScreen.x >= Screen.width - bordersize)cappedtargetPositionScreen.x=Screen.width - bordersize;
            if(cappedtargetPositionScreen.y <= bordersize)cappedtargetPositionScreen.y=bordersize;
            if(cappedtargetPositionScreen.y >= Screen.height - bordersize)cappedtargetPositionScreen.y=Screen.height - bordersize;
        
            Vector3 pointerWorldPosition = uiCamera.ScreenToWorldPoint(cappedtargetPositionScreen);
            
            PointerRectTransform.position = pointerWorldPosition;
            PointerRectTransform.localPosition = new Vector3(PointerRectTransform.localPosition.x, PointerRectTransform.localPosition.y, 0f);
        }else{
            pointerImage.sprite = crossSprite;
            Vector3 pointerWorldPosition = uiCamera.ScreenToWorldPoint(targetPositionScreenPoint);
            PointerRectTransform.position = pointerWorldPosition;
            PointerRectTransform.localPosition = new Vector3(PointerRectTransform.localPosition.x,PointerRectTransform.localPosition.y,0f);
        }
    }



}
