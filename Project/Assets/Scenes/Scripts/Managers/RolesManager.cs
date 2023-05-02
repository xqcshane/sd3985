using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using HashTable = ExitGames.Client.Photon.Hashtable;
using UnityEngine.SceneManagement;

public class RolesManager: MonoBehaviourPunCallbacks
{
    private int mystatus;
    private PhotonView _pv;
    public float totaltime = 10.0f;

    public Status MyStatusScript;
    // Start is called before the first frame update
    void Start()
    {
        MyStatusScript = GameObject.FindGameObjectWithTag("Status").GetComponent<Status>();
        _pv = this.gameObject.GetComponent<PhotonView>();
        if (PhotonNetwork.IsMasterClient)
        {
            HashTable table1 = new HashTable();
            table1.Add("Round", MyStatusScript.round);
            table1.Add("Turn", MyStatusScript.turn);
            PhotonNetwork.LocalPlayer.SetCustomProperties(table1);

            if (MyStatusScript.turn == 1)
            {
                mystatus = Random.Range(0, 2);
                InitialStatues(mystatus);
                HashTable table = new HashTable();
                int otherstatus = System.Math.Abs(mystatus - 1);
                table.Add("status", otherstatus);
                PhotonNetwork.LocalPlayer.SetCustomProperties(table);
            }
            else if (MyStatusScript.turn == 2)
            {
                if (_pv.IsMine)
                {
                    mystatus = (int)System.Math.Abs(MyStatusScript.status - 1);
                    InitialStatues(mystatus);
                    HashTable table = new HashTable();
                    int otherstatus = System.Math.Abs(mystatus - 1);
                    table.Add("status", otherstatus);
                    PhotonNetwork.LocalPlayer.SetCustomProperties(table);
                }
            }
        }
    }


    public override void OnPlayerPropertiesUpdate(Photon.Realtime.Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if(!_pv.IsMine && targetPlayer == _pv.Owner)
        {
            if (changedProps.ContainsKey("status"))
            {
                int nowstatus = (int)changedProps["status"];
                InitialStatues(nowstatus);
            }
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

    public void InitialStatues(int nowstatus)
    {
        GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().status = nowstatus;
        if(nowstatus == 0){
            GameObject.Find("Adventure").SetActive(true);
            GameObject.Find("Troublemaker").SetActive(false);
        }else{
            GameObject.Find("Adventure").SetActive(false);
            GameObject.Find("Troublemaker").SetActive(true);
        }
    }

    private void Update()
    {
        //Changeicon();
        if (totaltime > 0)
        {
            totaltime -= Time.deltaTime;
        }
        else
        {
            next();
        }
    }
    public int[] UniqRandom(int RandomNumber, int NeedNumber)
    {
        int[] randomskills = new int[NeedNumber];
        int maxnumber = 0;
        while (maxnumber < NeedNumber)
        {
            int num = Random.Range(1, RandomNumber+ 1);
            bool isOnList = false;
            foreach (int i in randomskills)
            {
                if (i == num)
                {
                    isOnList = true;
                }
            }
            if (!isOnList)
            {
                randomskills[maxnumber] = num;
                maxnumber++;
            }
        }
        for (int i = 0; i < randomskills.Length; i++)
        {
            randomskills[i] = randomskills[i] - 1;
        }
        return randomskills;
    }
    public void next()
    {
      
        SceneManager.LoadScene("New2SkillChoosing");
    }
}
