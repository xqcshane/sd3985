using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class FakeTrophy : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().ChangeHealth(-10);
            PhotonNetwork.Destroy(gameObject);
        }
    }
}
