using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class CreateTrophy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int role = GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().status;
        if (role == 0)
        {
            PhotonNetwork.Instantiate("Trophy", this.transform.position, Quaternion.identity);
        }
        
    }

    // Update is called once per frame
   
}
