using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Photon.Pun;

public class PlayerMove : MonoBehaviour
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
    public int currentweaponindex;

    public bool inpassage = false;
    public Animator animator;
    private bool faceRight = true;
    public Animator weaponAnimator;
   // public Animator weaponAnimator2;
  //  public Animator weaponAnimator3;
   // public Animator weaponAnimator4;
    public string A1;
    public string A2;
    public bool NotHit = true;
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        originalSpeed = speed;
        _pv = this.gameObject.GetComponent<PhotonView>();

        GameController = GameObject.Find("Controller").GetComponent<Controller>();
        PR = GameController.PlayerRole;

        if (_pv.IsMine)
        {
           InitalGame();
        }
        A1 = "weapon";
        A2 = "weapon_flip";


    }

    private void InitalGame()
    {
        GameObject.Find("Main Camera").GetComponent<CameraController>().MyPlayer = this.gameObject;
        GameObject.Find("Skill").GetComponent<SkillController>().player=this.gameObject;
        GameObject.Find("HealthBar").GetComponent<HealthBar>().initialHealth(this.gameObject.GetComponent<PlayerHealth>());
    }

    void Update()
    {
        currentweaponindex = this.gameObject.GetComponent<PlayerAim>().currentweaponindex;
    }
    private void FixedUpdate()
    {
        if (PR == 0)
        {
            if (NotHit)
            {
                if (canMove)
                {
                    if (slower)
                    {
                        speed = originalSpeed * 0.1f;
                    }
                    float horizontal = Input.GetAxis("Horizontal");
                    float vertical = Input.GetAxis("Vertical");


                    if (horizontal > 0)
                    {
                        animator.Play("Adventurer_right");
                        faceRight = true;
                        weaponAnimator.Play(A2);
                 
                    }
                    else if (horizontal < 0)
                    {
                        animator.Play("Adventurer_left");
                        faceRight = false;
                        weaponAnimator.Play(A1);
                     
                    }
                    else if (vertical != 0)
                    {
                        if (faceRight)
                        {
                            animator.Play("Adventurer_right");
                            weaponAnimator.Play(A2);
                        }
                        else
                        {
                            animator.Play("Adventurer_left");
                            weaponAnimator.Play(A1);
                        }

                    }
                    else
                    {
                        if (faceRight)
                        {
                            animator.Play("Real_adventurer");
                            weaponAnimator.Play(A2);
                        }
                        else
                        {
                            animator.Play("Real_adventurer_Flip");
                            weaponAnimator.Play(A1);
                        }

                    }

                    Vector2 position = transform.position;
                    position.x = position.x + speed * horizontal;
                    position.y = position.y + speed * vertical;
                    transform.position = position;
                }
            }
        }
    }

    }
