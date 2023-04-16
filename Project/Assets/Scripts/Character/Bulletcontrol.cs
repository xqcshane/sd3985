using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletcontrol : MonoBehaviour
{
    public float damage=0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") )
        {
            collision.gameObject.GetComponent<Enemyfollow>().health -= damage;
         Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Respawn"))
        {
            Destroy(gameObject);
        }
    }
}
