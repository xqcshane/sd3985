using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public int score;
    public float Preparetime = 30.0f;
    public float Gametime = 90.0f;
    public Text time;
    public int PlayerRole;

    public bool GameStart;
    //0 is adventure, 1 is troublemake

    /*
    private Controller GameController;
    private int PR;

    GameController = GameObject.Find("Controller").GetComponent<Controller>();
    PR = GameController.PlayerRole;
    */

    void Start()
    {
        GameObject Status = GameObject.FindGameObjectWithTag("Status");
        PlayerRole = Status.GetComponent<Status>().status;
        GameStart = false;
        if(PlayerRole == 1){
            GameObject.Find("AdventureUIAndUICamera").SetActive(false);
            PhotonNetwork.Instantiate("TroubleMake", new Vector3(200f,70f,0f), Quaternion.identity);
        }
        else
        {
            PhotonNetwork.Instantiate("Player", new Vector3(12f, 7f, 0f), Quaternion.identity);
            EnemyCreation();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Preparetime > 0)
        {
            GameStart = false;
            Preparetime-= Time.deltaTime;
            //time.text = "Time Remain:" + ((int)totaltime).ToString();
            time.text = ((int)Preparetime).ToString();
            time.color = Color.yellow;
        }
        else if(Gametime > 0)
        {
            GameStart = true;
            Gametime-= Time.deltaTime;
            //time.text = "Time Remain:" + ((int)totaltime).ToString();
            time.text = ((int)Gametime).ToString();
            time.color = Color.white;
        }else{
            Debug.Log("Out Of Time0");
        }
    }
    
    void EnemyCreation(){
        for(int i=0;i<10;i++){
        PhotonNetwork.Instantiate("Enemy", new Vector3(83f, 93f, 0f), Quaternion.identity);
        }
        for(int i=0;i<10;i++){
        PhotonNetwork.Instantiate("Enemy", new Vector3(93f, 112f, 0f), Quaternion.identity);
        }
        for(int i=0;i<10;i++){
        PhotonNetwork.Instantiate("Enemy", new Vector3(110f, 96f, 0f), Quaternion.identity);
        }
    }
}
