using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public int score;
    public float totaltime = 90.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (totaltime > 0)
        {
            totaltime-= Time.deltaTime;
            Debug.Log(totaltime);
        }
        else
        {
            Debug.Log("Running out time");
        }
    }
}
