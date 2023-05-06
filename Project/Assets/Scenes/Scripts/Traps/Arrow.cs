using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Unity.Mathematics;

public class Arrow : MonoBehaviour
{
    public float MAXShootDistance = 50.0f;
    Rigidbody2D rigidbody2d;
    private Vector3 startposition;
    private float nowgap;
    private int PR;
    private PhotonView PV;
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        startposition = transform.position;

        PR = GameObject.Find("Controller").GetComponent<Controller>().PlayerRole;
        PV = GetComponent<PhotonView>();
    }

    public void Launch(Vector2 direction, float speed)
    {
        if (PR==0)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = gameObject.transform.up * speed;
        }
    }

    void Update()
    {
        if (PR==0)
        {
            nowgap = math.abs((transform.position - startposition).magnitude);
            if (nowgap > MAXShootDistance)
            {
                PhotonNetwork.Destroy(gameObject);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (PR == 0)
        {
            if (collision.gameObject.CompareTag("Player"))
            {

                collision.gameObject.GetComponent<PlayerHealth>().ChangeHealth(-5);
                PhotonNetwork.Destroy(gameObject);

            }
            if (collision.gameObject.CompareTag("Wall"))
            {
                PhotonNetwork.Destroy(gameObject);
            }
        }
    }
}