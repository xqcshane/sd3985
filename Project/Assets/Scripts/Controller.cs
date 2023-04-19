using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public int score;
    public float totaltime = 90.0f;
    public Text time;
    public int PlayerRole;
    //0 is adventure, 1 is troublemake

    /*
    private Controller GameController;
    private int PR;

    GameController = GameObject.Find("Controller").GetComponent<Controller>();
    PR = GameController.PlayerRole;
    */

    void Start()
    {
        if(PlayerRole == 1){
            GameObject.Find("AdventureUIAndUICamera").SetActive(false);
            //GameObject.Find("Player").GetComponent<PhotonView>().IsMine = false;
            PhotonNetwork.Instantiate("TroubleMake", new Vector3(85f,85f,0f), Quaternion.identity);
        }else{
            //GameObject.Find("TroubleMake").GetComponent<PhotonView>().IsMine = false;
            PhotonNetwork.Instantiate("Player", new Vector3(80f,85f,0f), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (totaltime > 0)
        {
            totaltime-= Time.deltaTime;
            //time.text = "Time Remain:" + ((int)totaltime).ToString();
            time.text = ((int)totaltime).ToString();
        }
        else
        {
            Debug.Log("Running out time");
        }
    }
}
