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

    public Animator animator;
    private bool faceRight = true;

    // �ڵ�һ��֡����֮ǰ���� Start
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        originalSpeed = speed;
        _pv = this.gameObject.GetComponent<PhotonView>();

        GameController = GameObject.Find("Controller").GetComponent<Controller>();
        PR = GameController.PlayerRole;

        if (_pv.IsMine)
        {
            GameObject.Find("Main Camera").GetComponent<CameraController>().MyPlayer = this.gameObject;
        }
    }

    // ÿ֡����һ�� Update
    void Update()
    {
      
    }
    private void FixedUpdate()
    {
        if (PR == 1)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            if (horizontal > 0)
            {
                animator.Play("reverager_right");
                faceRight = true;
            }
            else if (horizontal < 0)
            {
                animator.Play("reverager_left");
                faceRight = false;
            }
            else if (vertical != 0)
            {
                if (faceRight)
                {
                    animator.Play("reverager_right");
                }
                else
                {
                    animator.Play("reverager_left");
                }

            }
            else
            {
                if (faceRight)
                {
                    animator.Play("reverager_idle");
                }
                else
                {
                    animator.Play("reverager_idle_Flip");
                }

            }

            Vector2 position = transform.position;
            position.x = position.x + speed * horizontal;
            position.y = position.y + speed * vertical;
            transform.position = position;
        }
    }
    }
