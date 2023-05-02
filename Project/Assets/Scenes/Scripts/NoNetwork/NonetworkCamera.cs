using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonetworkCamera : MonoBehaviour
{
    public GameObject MyPlayer;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (MyPlayer != null)
        {
            transform.position = new Vector3(MyPlayer.transform.position.x, MyPlayer.transform.position.y, transform.position.z);
        }
    }
}
