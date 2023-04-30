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
    //[SerializeField]
    //Text RoomListText;
    [SerializeField]
    Button[] StartButtons;


    void Start()
    {
        SetAllBtns(false);

        if(PhotonNetwork.IsConnected==false){
            SceneManager.LoadScene("SL");
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

        SceneManager.LoadScene("RL");

        //show loading page
    }
   

    private void CreateRoom()
    {
        string roomName = Random.Range(1, 10000).ToString();
        PhotonNetwork.CreateRoom(roomName, new RoomOptions { MaxPlayers = 2, IsVisible = true });
    }

    public override void OnCreatedRoom(){
        PhotonNetwork.LocalPlayer.NickName = Random.Range(1, 10000).ToString();
        Debug.Log("Create successfully");
    }

    private void QuickMatch()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom(){
        PhotonNetwork.LocalPlayer.NickName = Random.Range(1, 10000).ToString();
        Debug.Log("Room Joined");
        SceneManager.LoadScene("QS");
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
         //RoomListText.text = sb.ToString();
         
     }

    public void loadIntro()
    {
        SceneManager.LoadScene("I1");
    }

    public void loadSetting()
    {
        SceneManager.LoadScene("S1");
    }
}