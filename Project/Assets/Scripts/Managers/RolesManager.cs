using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using HashTable = ExitGames.Client.Photon.Hashtable;


public class RolesManager:MonoBehaviourPunCallbacks 
{
    private int status;
    private PhotonView _pv;
    // Start is called before the first frame update
    void Start()
    {  
        _pv = this.gameObject.GetComponent<PhotonView>();   
        if (PhotonNetwork.IsMasterClient){
            int[] allstatus = UniqRandom(2,2);
            HashTable table = new HashTable();
            table.Add("status", allstatus[1]);
            PhotonNetwork.LocalPlayer.SetCustomProperties(table);
            InitialStatues(allstatus[0]);
        }
    }


    public override void OnPlayerPropertiesUpdate(Photon.Realtime.Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if(targetPlayer == _pv.Owner){
            int nowstatus = (int)changedProps["status"];
            InitialStatues(nowstatus);
        }
    }

    public void InitialStatues(int nowstatus)
    {
        GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().status = nowstatus;
        if(status == 0){
            GameObject.Find("Adventure").SetActive(true);
            GameObject.Find("Troublemaker").SetActive(false);
        }else{
            GameObject.Find("Adventure").SetActive(false);
            GameObject.Find("Troublemaker").SetActive(true);
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
}
