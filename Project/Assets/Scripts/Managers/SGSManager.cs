using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Text;
using Photon.Realtime;


public class SGSManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    Text RoomListText;
    [SerializeField]
    Button[] StartButtons;


    void Start()
    {
        SetAllBtns(false);

        if(PhotonNetwork.IsConnected==false){
            SceneManager.LoadScene("StartLoadingScene");
        }else{
            if(PhotonNetwork.CurrentLobby == null){
                PhotonNetwork.JoinLobby();
            }else{
                SetAllBtns(true);
            }
        }   


    }

    //set all buttons in the StartButtons list
    private void SetAllBtns(bool nowstatus){
        foreach(Button nowbt in StartButtons) {
            nowbt.interactable = nowstatus; 
        } 
    }

    //if Lobby Joined 
    public override void OnJoinedLobby(){
        Debug.Log("Lobby Joined");
    }

    //Click Quick Match
    public void OnQuickMatchBtn(){
        SetAllBtns(false);

        QuickMatch();
        Debug.Log("Click Start");

        //show loading page
    }

    public void OnRoomBtn(){
        SetAllBtns(false);

        SceneManager.LoadScene("RoomListScene");

        //show loading page
    }
   

    private void CreateRoom()
    {
        string roomName = Random.Range(1, 10000).ToString();
        PhotonNetwork.CreateRoom(roomName, new RoomOptions { MaxPlayers = 2, IsVisible = true });
    }

    public override void OnCreatedRoom(){
        PhotonNetwork.LocalPlayer.NickName = "Player1" ;
        Debug.Log("Create successfully");
    }

    private void QuickMatch()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom(){
        Debug.Log("Room Joined");
        SceneManager.LoadScene("RoomScene");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        CreateRoom();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
     {
         StringBuilder sb = new StringBuilder();
         foreach (RoomInfo roomInfo in roomList)
         {
            if(roomInfo.PlayerCount > 0){
                sb.AppendLine("-> "+ roomInfo.Name + "   " +roomInfo.PlayerCount.ToString());
            } 
         }
         RoomListText.text = sb.ToString();
         
     }
}