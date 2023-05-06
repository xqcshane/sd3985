using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Photon.Pun;

public class BossRoomChecker : MonoBehaviour
{
    // Start is called before the first frame update
    int role;
    void Start()
    {
        role = GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().status;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (role == 0){
            if (collision.gameObject.CompareTag("Player"))
            {
                PhotonNetwork.Instantiate("BossRoomBlocks", this.transform.parent.transform.parent.transform.position, Quaternion.identity);
                GameObject MyBoss = PhotonNetwork.Instantiate("Boss", this.transform.position, Quaternion.identity);
                //GameObject.Find("EmojiSystem").transform.GetChild(0).transform.GetChild(1).gameObject.GetComponent<BossHealthBar>().initialHealth(MyBoss.gameObject.GetComponent<BossFollow>());
               
                Destroy(gameObject);
            }
             
        }



    }
}
