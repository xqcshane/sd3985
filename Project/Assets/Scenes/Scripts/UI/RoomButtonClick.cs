using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class RoomButtonClick : MonoBehaviourPunCallbacks
{
    public string roomName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickMyBtn(){
        PhotonNetwork.JoinRoom(roomName);
    }

    public override void OnJoinedRoom(){
        Debug.Log("Room Joined");
        SceneManager.LoadScene("RoomScene");
    }
}
