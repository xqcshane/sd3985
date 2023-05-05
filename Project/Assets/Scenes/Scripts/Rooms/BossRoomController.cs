using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BossRoomController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int status=GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().status;
        if (status == 0)
        {
            GameObject MyBoss = PhotonNetwork.Instantiate("Boss", this.transform.position, Quaternion.identity);
            GameObject.Find("BossHealthBar").GetComponent<BossHealthBar>().initialHealth(MyBoss.gameObject.GetComponent<BossFollow>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
