using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Photon.Pun;

public class TroubleMakeMove : MonoBehaviour
{
    public float speed;
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    public bool canMove;
    public bool slower;
    public float originalSpeed;

    private Controller GameController;
    private int PR;
    private PhotonView _pv;
    // �ڵ�һ��֡����֮ǰ���� Start
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        originalSpeed = speed;
        _pv = this.gameObject.GetComponent<PhotonView>();

        GameController = GameObject.Find("Controller").GetComponent<Controller>();
        PR = GameController.PlayerRole;
    }

    // ÿ֡����һ�� Update
    void Update()
    {
      
    }
    private void FixedUpdate()
    {
        if( _pv.IsMine && PR == 1)
        {
            if (canMove)
                {
                    if (slower)
                    {
                        speed = originalSpeed * 0.1f;
                    }
                    float horizontal = Input.GetAxis("Horizontal");
                    float vertical = Input.GetAxis("Vertical");

                    Vector2 position = transform.position;
                    position.x = position.x + speed * horizontal;
                    position.y = position.y + speed * vertical;
                    transform.position = position;
                }
            }
        }
    }
