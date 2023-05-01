using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class TMSetTrapViewController : MonoBehaviour
{
    private Controller GameController;
    private int PR;

    float timerForDoubleClick = 0.0f;
	float delay = 0.3f;
	bool isDoubleClick = false;

    public bool CanChangeView;
	
    //public float CameraMaxSize;
    //public float CameraMinSize;
    // Start is called before the first frame update
    void Start()
    {
        GameController = GameObject.Find("Controller").GetComponent<Controller>();
        PR = GameController.PlayerRole;
    }

    // Update is called once per frame
    void Update()
    {
        if(PR == 1 && CanChangeView){
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log ("Mouse clicked once");

                if(isDoubleClick == true && timerForDoubleClick < delay){
                    timerForDoubleClick = 0.0f;
                    isDoubleClick = false;
                    //Camera.main.orthographicSize = 8;
                    this.gameObject.transform.position = UtilsClass.GetMouseWorldPosition();
                }else{
                    isDoubleClick = true;
                }          
            }

            if (timerForDoubleClick >= delay)
            {
                timerForDoubleClick = 0.0f;
                isDoubleClick = false;
            }

            if (Input.GetKeyDown("space"))
            {
                Camera.main.orthographicSize = 16f;
            }

            if (Input.GetKey(KeyCode.Q)){
                Camera.main.orthographicSize = Camera.main.orthographicSize + 0.03f;

            }
            if (Input.GetKey(KeyCode.E)){
                if(Camera.main.orthographicSize > 0f){
                    Camera.main.orthographicSize = Camera.main.orthographicSize - 0.03f;     
                }
      
            }

            float  mouseCenter = Input.GetAxis("Mouse ScrollWheel");

            if (mouseCenter <0  ) {        
                //if (c.fieldOfView <= maxView) {
                    Camera.main.orthographicSize = Camera.main.orthographicSize + 0.2f;
                //}     
          
            } else if (mouseCenter >0 ) {
                if(Camera.main.orthographicSize > 0f){
                    Camera.main.orthographicSize = Camera.main.orthographicSize - 0.2f;     
                }
        
            }

            if (Input.GetKey(KeyCode.R)){
                Camera.main.orthographicSize = 100f;    
                this.gameObject.transform.position = new Vector3(200f,70f,0f); 
            }
            
            if (Input.GetKey(KeyCode.F)){
                Camera.main.orthographicSize = 100f;    
            }
        }   else if (!CanChangeView)
        {
            if (PR == 1)
            {
                Camera.main.orthographicSize = 16f;
            }       
        }
    }
}
