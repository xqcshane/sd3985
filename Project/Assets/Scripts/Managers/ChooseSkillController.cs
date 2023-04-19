using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ChooseSkillController : MonoBehaviour
{
    private int status;
    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            status = 0;
            GameObject.Find("Adventure").SetActive(true);
            
            GameObject.Find("Troublemaker").SetActive(false);
        }
        else
        {
            status = 1;
            GameObject.Find("Adventure").SetActive(false);

            GameObject.Find("Troublemaker").SetActive(true);
        }

        GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().status = status;
    }

}
