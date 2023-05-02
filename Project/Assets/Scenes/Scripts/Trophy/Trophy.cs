using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SocialPlatforms.Impl;


public class Trophy : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("Controller").GetComponent<Controller>().collected += 1;
            if (GameObject.FindGameObjectWithTag("Controller").GetComponent<Controller>().collected == 1|| GameObject.FindGameObjectWithTag("Controller").GetComponent<Controller>().collected == 2)
            {
                GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreController>().addScore(50);
            }
            else if(GameObject.FindGameObjectWithTag("Controller").GetComponent<Controller>().collected == 3)
            {
                GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreController>().addScore(150);
                //PhotonNetwork.Instantiate("Gate", this.transform.position, this.transform.rotation);
            }
            PhotonNetwork.Destroy(this.gameObject);
        }
    }
}
