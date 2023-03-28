using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Text;
using Photon.Realtime;

public class RLSManager : MonoBehaviourPunCallbacks
{
    [SerializeField] 
    public Transform m_ContentContainer;

    public Button ButtonPrefab;
    // Start is called before the first frame update
    void Start()
    {
        if(PhotonNetwork.IsConnected==false){
            SceneManager.LoadScene("StartGameScene");
        }else{
            if(PhotonNetwork.CurrentLobby == null){
                PhotonNetwork.JoinLobby();
            }
        }       
        
    }

    public override void OnConnectedToMaster(){
        Debug.Log("Connected to Master");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby(){
        Debug.Log("Lobby Joined");
    }

    public void OnClickCreateRoom(){
        string roomName = Random.Range(1, 10000).ToString();
        PhotonNetwork.CreateRoom(roomName, new RoomOptions { MaxPlayers = 2, IsVisible = true });
    }

    public override void OnCreatedRoom(){
        PhotonNetwork.LocalPlayer.NickName = "Player1" ;
        Debug.Log("Create successfully");
    }

    public override void OnJoinedRoom(){
        Debug.Log("Room Joined");
        SceneManager.LoadScene("RoomScene");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList){
        
        int nbChildren = m_ContentContainer.childCount;

        for (int i = nbChildren - 1; i >= 0; i--) {
            DestroyImmediate(m_ContentContainer.GetChild(i).gameObject);
        }

        foreach(RoomInfo roomInfo in roomList){
            if(roomInfo.PlayerCount > 0){               
                Button choiceButton = Instantiate(ButtonPrefab, this.transform);
                // Return a reference to this component and save it locally.
                Text choiceText = choiceButton.GetComponentInChildren<Text>();
                // Set the button's text to the choice's text
                choiceText.text = roomInfo.Name;   
                //set button variable
                choiceButton.GetComponent<RoomButtonClick>().roomName = roomInfo.Name;    
                choiceButton.transform.SetParent(m_ContentContainer);  
    
            }         
        }

    }

    public void OnClickBack(){
        SceneManager.LoadScene("StartGameScene");
    }
}
