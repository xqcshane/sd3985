using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class Bulletcontrol : MonoBehaviour
{
    public float damage=0;
    private Controller GameController;
    private int PR;
    public float exsittime = 100f;
    public float speed = 10.0f;
    public PhotonView pv;
    private void Start()
    {
        GameController = GameObject.Find("Controller").GetComponent<Controller>();
        PR = GameController.PlayerRole;
        pv=this.gameObject.GetComponent<PhotonView>();
        if (!pv.IsMine)
        {
            Destroy(this.gameObject.GetComponent<Rigidbody2D>());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<NonetworkEnemy>().Damaged(damage);
            PhotonNetwork.Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("FlyingEye"))
        {
            collision.gameObject.GetComponent<NoNetworkFlyingEye>().Damaged(damage);
            PhotonNetwork.Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Mushroom"))
        {
            collision.gameObject.GetComponent<NoNetworkMushroom>().Damaged(damage);
            PhotonNetwork.Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Seleton"))
        {
            collision.gameObject.GetComponent<NoNetworkSkeleton>().Damaged(damage);
            PhotonNetwork.Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            PhotonNetwork.Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("BOSS"))
        {
            collision.gameObject.GetComponent<BossFollow>().Damaged(damage);
            PhotonNetwork.Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (PR == 0)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = gameObject.transform.right * speed;


            //bulletrb.velocity = bullets.transform.right * speed;
            if (exsittime > 0)
            {
                exsittime -= Time.deltaTime;
            }
            else
            {
               PhotonNetwork.Destroy(gameObject);
            }
        }
    }
}
