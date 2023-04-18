using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSlower : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D collision)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<PlayerMove>().slower = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerMove>().slower = false;
        player.GetComponent<PlayerMove>().speed = player.GetComponent<PlayerMove>().originalSpeed;
    }
}
