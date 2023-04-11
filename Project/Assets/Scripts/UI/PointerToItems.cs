using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using CodeMonkey.Utils;

public class PointerToItems : MonoBehaviour
{
    [SerializeField]
    private Camera uiCamera;
    [SerializeField]
    private Sprite arrowSprite;
    [SerializeField]
    private Sprite crossSprite;
    
    private Vector3 targetPosition;
    private RectTransform PointerRectTransform;
    private Image pointerImage;
    

    public GameObject[] respawns;

    private void Awake(){
        
        respawns = GameObject.FindGameObjectsWithTag("Respawn");
        
        targetPosition = new Vector3(200,45);
        PointerRectTransform = transform.Find("Pointer").GetComponent<RectTransform>();
        pointerImage = transform.Find("Pointer").GetComponent<Image>();
    }

    private void Update(){
        Vector3 toPosition = targetPosition;
        Vector3 fromPosition = Camera.main.transform.position;
        fromPosition.z = 0f;
        Vector3 dir = (toPosition - fromPosition).normalized;
        float angle = Vector3.Angle(dir, respawns[0].transform.position);
        PointerRectTransform.localEulerAngles = new Vector3(0,0,angle);

        float bordersize = 100f;
        Vector3 targetPositionScreenPoint = Camera.main.WorldToScreenPoint(targetPosition);
        bool isOffScreen = targetPositionScreenPoint.x <= bordersize || targetPositionScreenPoint.x >= Screen.width-bordersize || targetPositionScreenPoint.y<=bordersize || targetPositionScreenPoint.y >= Screen.height-bordersize;
        if (isOffScreen){
            pointerImage.sprite = arrowSprite;
            Vector3 cappedtargetPositionScreen = targetPositionScreenPoint;
            if(cappedtargetPositionScreen.x<=bordersize)cappedtargetPositionScreen.x=bordersize;
            if(cappedtargetPositionScreen.x>= Screen.width - bordersize)cappedtargetPositionScreen.x=Screen.width - bordersize;
            if(cappedtargetPositionScreen.y<=bordersize)cappedtargetPositionScreen.y=bordersize;
            if(cappedtargetPositionScreen.y<=Screen.height - bordersize)cappedtargetPositionScreen.y=Screen.height - bordersize;
        
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
