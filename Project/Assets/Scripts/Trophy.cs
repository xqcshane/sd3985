using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SocialPlatforms.Impl;


public class Trophy : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreController>().addScore(50);
            PhotonNetwork.Destroy(gameObject);
        }
    }
}
