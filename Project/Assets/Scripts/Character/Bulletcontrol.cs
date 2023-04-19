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
            collision.gameObject.GetComponent<Enemyfollow>().animator.Play("globin_hit");
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
