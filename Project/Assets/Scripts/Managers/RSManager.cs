using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text;
using Photon.Realtime;

public class RSManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    Text textRoonName;
    [SerializeField]
    Text textPlayerList;

    // Start is called before the first frame update
    void Start()
    {
        if(PhotonNetwork.CurrentRoom == null){
            SceneManager.LoadScene("StartGameScene");
        }else{
            textRoonName.text = PhotonNetwork.CurrentRoom.Name;
            UpdatePlayerList();
        }

    }

    public override void OnMasterClientSwitched(Player newMasterClient){
        
    }

    public void UpdatePlayerList(){
        StringBuilder sb = new StringBuilder();
        int CountPlayerNum = 0;
        foreach (Player player in PhotonNetwork.PlayerList) 
        {
            sb.AppendLine("-> "+ player.NickName);
            CountPlayerNum++;
        }
        textPlayerList.text = sb.ToString();
        
        if(CountPlayerNum == 2){
            /*
            if(PhotonNetwork.IsMasterClient){
                PhotonNetwork.LocalPlayer.NickName = "Player1" ;
            }else{
                PhotonNetwork.LocalPlayer.NickName = "Player2" ;
            }
            */
           OnClickStartGame(); 
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer){
        UpdatePlayerList();
    }

    public override void OnPlayerLeftRoom(Player newPlayer){
        UpdatePlayerList();
    }

    public void OnClickStartGame(){
        SceneManager.LoadScene("SkillChoosing");
    }

    public void OnClickLeaveRoom(){
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom(){
        SceneManager.LoadScene("StartGameScene");
    }
}
