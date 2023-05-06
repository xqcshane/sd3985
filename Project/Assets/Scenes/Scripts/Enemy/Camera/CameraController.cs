using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject MyPlayer;
    
    private Controller GameController;
    private int PR;
    // Start is called before the first frame update
    void Start()
    {
        GameController = GameObject.Find("Controller").GetComponent<Controller>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MyPlayer != null)
        {
            transform.position = new Vector3(MyPlayer.transform.position.x, MyPlayer.transform.position.y, transform.position.z);
        }
    }
}