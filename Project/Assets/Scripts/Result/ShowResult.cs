using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using ExitGames.Client.Photon;
using Photon.Pun;
using HashTable = ExitGames.Client.Photon.Hashtable;
using TMPro;
using System.Data;

public class ShowResult : MonoBehaviourPunCallbacks
{
    GameObject final;
    public Text result;
    public Text score;

    //public Text result2;
    public Text score2;
    public float showtime = 10.0f;
    public TextMeshProUGUI MyRAT;

    public Status MyStatusScript;
    private PhotonView _pv;
    void Start()
    {
        _pv = this.gameObject.GetComponent<PhotonView>();
        final = GameObject.FindGameObjectWithTag("Result");
        int myrole = final.GetComponent<Result>().PR;
        if (myrole == 0)
        {
            GameObject.Find("Adventure").SetActive(true);
            GameObject.Find("Troublemaker").SetActive(false);
            
            if (!final.GetComponent<Result>().death)
            {
                result.text = "Time Out";
                score.text = "Your total score is :" + (final.GetComponent<Result>().score).ToString();
            }
            else
            {
                result.text = "You Dead";
                score.text = "GameOver";
            }
        }
        else
        {
            GameObject.Find("Adventure").SetActive(false);
            GameObject.Find("Troublemaker").SetActive(true);
            if (!final.GetComponent<Result>().death)
            {
                score2.text = "You Block the Adventure";
            }
            else
            {
                score2.text = "You Kill the Adventure";
            }
        }
        Destroy(GameObject.Find("Data1"));
        Destroy(GameObject.Find("Data2"));
        Destroy(GameObject.Find("result"));

        MyStatusScript = GameObject.FindGameObjectWithTag("Status").GetComponent<Status>();

        if (PhotonNetwork.IsMasterClient)
        {
            int MyRound = GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().round;
            int MyTurn = GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().turn;
            if (MyTurn == 1)
            {
                GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().turn = 2;
                SceneManager.LoadScene("Roles");
            }
            else if (MyTurn == 2)
            {
                GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().round++;
                GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().turn = 1;
            }
            HashTable table1 = new HashTable();
            table1.Add("Round", MyStatusScript.round);
            table1.Add("Turn", MyStatusScript.turn);
            PhotonNetwork.LocalPlayer.SetCustomProperties(table1);
            ShowTurnAndRound();
        }

        // Destroy(GameObject.)

    }

    private void Update()
    {
        if (showtime > 0)
        {       
            showtime -= Time.deltaTime;
        }
        else
        {
            CheckAndChangeScene();
        }
    }


    public void CheckAndChangeScene()
    {
        int MyRound = GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().round;
        int MyTurn = GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().turn;
        if(MyRound == 3 && MyTurn == 2)
        {
            SceneManager.LoadScene("Score");
        }else {
            SceneManager.LoadScene("Roles");
        }
    }


    public override void OnPlayerPropertiesUpdate(Photon.Realtime.Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if (!_pv.IsMine && targetPlayer == _pv.Owner)
        {
            if (changedProps.ContainsKey("Round"))
            {
                int NowR = (int)changedProps["Round"];
                MyStatusScript.round = NowR;
            }
            if (changedProps.ContainsKey("Turn"))
            {
                int NowT = (int)changedProps["Turn"];
                MyStatusScript.turn = NowT;
            }
        }
    }

    public void ShowTurnAndRound()
    {
        MyRAT.text = "Round: " + (int)GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().round + "/nTurn: " + (int)GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().turn;   
    }

}
