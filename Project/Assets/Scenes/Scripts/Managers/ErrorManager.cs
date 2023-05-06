using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System.Text;
using Photon.Realtime;

public class ErrorManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.CurrentRoom == null)
        {
            SceneManager.LoadScene("ErrorScene");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdatePlayerList()
    {
        int CountPlayerNum = 0;
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            CountPlayerNum++;
        }
       

        if (CountPlayerNum != 2)
        {
            SceneManager.LoadScene("ErrorScene");
        }
    }

    public override void OnPlayerLeftRoom(Player newPlayer)
    {
        UpdatePlayerList();
    }
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("ErrorScene");
    }
}
