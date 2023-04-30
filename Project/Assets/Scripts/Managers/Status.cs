using ExitGames.Client.Photon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using HashTable = ExitGames.Client.Photon.Hashtable;

public class Status : MonoBehaviourPunCallbacks
{
    //player role, 0 is adventure, 1 is troblemaker
    public int status;
    //game round
    public int round;
    //turn in each round, 1 is turn 1, 2 is turn 2
    public int turn;
    //score of round 1 2 3
    public int score1;
    public int score2;
    public int score3;

    //room information of the room
    public int[] roominfo;

    private void Start()
    {
        round = 1;
        turn = 1;
    }
    public override void OnPlayerPropertiesUpdate(Photon.Realtime.Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if (changedProps.ContainsKey("MyRoomInfo"))
        {
            this.roominfo = (int[])changedProps["MyRoomInfo"];
        }
    }

    public void changeRoomInfo(int[] value)
    {
        roominfo = value; 
        HashTable table = new HashTable();
        table.Add("MyRoomInfo", roominfo);
        PhotonNetwork.LocalPlayer.SetCustomProperties(table);
    }

    public void SetScore(int nowscore)
    {
        switch (round)
        {
            case 1:
                score1 = nowscore;
                break;
            case 2:
                score2 = nowscore;
                break;
            case 3:
                score3 = nowscore;
                break;
            default:
                Debug.Log("Status SetScore error");
                break;
        }
    }
}
