using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrones : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().ChangeHealth(-5);
        }
    }
}
