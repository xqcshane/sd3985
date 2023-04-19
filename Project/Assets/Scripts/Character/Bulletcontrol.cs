using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletcontrol : MonoBehaviour
{
    public float damage=0;
    float playtime=0f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") )
        {
           
                playtime = Time.time + 0.5f;
                collision.gameObject.GetComponent<Enemyfollow>().health -= damage;
                collision.gameObject.GetComponent<Enemyfollow>().animator.SetBool("hit", true);
            if (Time.time > playtime)
            {
                collision.gameObject.GetComponent<Enemyfollow>().animator.SetBool("hit", false);
            }
            Destroy(gameObject);
            
        }
        if (collision.gameObject.CompareTag("Respawn"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("BOSS"))
        {
            collision.gameObject.GetComponent<BossFollow>().health -= damage;
            Destroy(gameObject);
        }
    }
}
