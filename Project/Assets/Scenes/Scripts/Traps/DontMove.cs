using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontMove : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(MyCoroutine());
        }
    }

    private IEnumerator MyCoroutine()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerMove>().canMove = false;
        yield return new WaitForSeconds(1f);
        player.GetComponent<PlayerMove>().canMove = true;
        yield return null;
    }
}
