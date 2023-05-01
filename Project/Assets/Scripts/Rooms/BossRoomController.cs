using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BossRoomController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        GameObject MyBoss = PhotonNetwork.Instantiate("Boss", this.transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
