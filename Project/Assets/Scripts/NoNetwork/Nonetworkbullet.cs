using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nonetworkbullet : MonoBehaviour
{
    public float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<NonetworkEnemy>().Damaged(damage);
            //collision.gameObject.GetComponent<NonetworkEnemy>().health -= damage;
            //collision.gameObject.GetComponent<Enemyfollow>().animator.Play("globin_hit");
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("FlyingEye"))
        {
            collision.gameObject.GetComponent<NoNetworkFlyingEye>().Damaged(damage);
            //collision.gameObject.GetComponent<NonetworkEnemy>().health -= damage;
            //collision.gameObject.GetComponent<Enemyfollow>().animator.Play("globin_hit");
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Mushroom"))
        {
            collision.gameObject.GetComponent<NoNetworkMushroom>().Damaged(damage);
            //collision.gameObject.GetComponent<NonetworkEnemy>().health -= damage;
            //collision.gameObject.GetComponent<Enemyfollow>().animator.Play("globin_hit");
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Seleton"))
        {
            collision.gameObject.GetComponent<NoNetworkSkeleton>().Damaged(damage);
            //collision.gameObject.GetComponent<NonetworkEnemy>().health -= damage;
            //collision.gameObject.GetComponent<Enemyfollow>().animator.Play("globin_hit");
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Respawn"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("BOSS"))
        {
            collision.gameObject.GetComponent<BossFollow>().Damaged(damage);
            //collision.gameObject.GetComponent<BossFollow>().health -= damage;
            Destroy(gameObject);
        }
    }
}
