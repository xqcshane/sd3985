using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;


public class ErrorSceneController : MonoBehaviourPunCallbacks
{
    GameObject final;

    //public Text result2;
    public float showtime = 5.0f;
    void Start()
    {
        final = GameObject.FindGameObjectWithTag("Status");
        int myrole = final.GetComponent<Status>().status;
        if (myrole == 0)
        {
            GameObject.Find("Adventure").SetActive(true);
            GameObject.Find("Troublemaker").SetActive(false);

            
        }
        else
        {
            GameObject.Find("Adventure").SetActive(false);
            GameObject.Find("Troublemaker").SetActive(true);
           
        }
        Destroy(GameObject.FindGameObjectWithTag("SkillData"));
        Destroy(GameObject.FindGameObjectWithTag("TrapData"));
        Destroy(GameObject.FindGameObjectWithTag("Status"));
        //Destroy(GameObject.Find("result"));
        // Destroy(GameObject.)

    }

    private void Update()
    {
        if (showtime > 0)
        {
            showtime -= Time.deltaTime;
        }
        else
        {
            SceneManager.LoadScene("1");
            //PhotonNetwork.LeaveRoom();
        }
    }
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("1");
    }
}