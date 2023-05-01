using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class EnterNext : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (PhotonNetwork.IsMasterClient){
                GameObject.FindGameObjectWithTag("Controller").GetComponent<Controller>().endGame = true;
            }
        }
          
    }
}
