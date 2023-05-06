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

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        startposition = transform.position;
        
        PR = GameObject.Find("Controller").GetComponent<Controller>().PlayerRole;
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    void Update()
    {
        nowgap = math.abs((transform.position - startposition).magnitude);
        if (nowgap > MAXShootDistance)
        {
            PhotonNetwork.Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(PR == 0)
            {
                collision.gameObject.GetComponent<PlayerHealth>().ChangeHealth(-5);
                PhotonNetwork.Destroy(gameObject);
            }
        }
    }
}
