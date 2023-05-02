using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using HashTable = ExitGames.Client.Photon.Hashtable;
using System.Data;

public class ScoreSceneManager : MonoBehaviourPunCallbacks
{
    public Score Youscore;

    public Score Otherscore;

    private Status mys;
    private int role;
    // Start is called before the first frame update
    void Start()
    {
        mys = GameObject.FindGameObjectWithTag("Status").GetComponent<Status>();
        role = mys.status;
        int[] MyScore = { role, mys.score1, mys.score2, mys.score3 };

        HashTable table = new HashTable();
        table.Add("MyScore", MyScore);
        PhotonNetwork.LocalPlayer.SetCustomProperties(table);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnPlayerPropertiesUpdate(Photon.Realtime.Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if (changedProps.ContainsKey("MyScore"))
        {
            int[] OScore = (int[])changedProps["MyScore"];
            if(role != OScore[0])
            {
                Otherscore.SetInitial(OScore[1], OScore[2], OScore[2]);

                Youscore.SetInitial(OScore[1], OScore[2], OScore[2]);
            }
        }
    }
}
