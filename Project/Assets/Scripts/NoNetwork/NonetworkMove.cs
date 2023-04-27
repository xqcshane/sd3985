using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonetworkMove : MonoBehaviour
{
    public float speed;
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    public bool canMove;
    public bool slower;
    public float originalSpeed;
    public bool inpassage=false;

    public Animator animator;

    private bool faceRight = true;

    public Animator weaponAnimator;

    private void FixedUpdate()
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
                weaponAnimator.Play("weapon_flip");
            }
            else if(horizontal < 0)
            {
                animator.Play("Adventurer_left");
                faceRight = false;
                weaponAnimator.Play("weapon");
            }
            else if(vertical != 0)
            {
                if (faceRight)
                {
                    animator.Play("Adventurer_right");
                    weaponAnimator.Play("weapon_flip");
                }
                else
                {
                    animator.Play("Adventurer_left");
                    weaponAnimator.Play("weapon");
                }
                
            }
            else
            {
                if (faceRight)
                {
                    animator.Play("Real_adventurer");
                    weaponAnimator.Play("weapon_flip");
                }
                else
                {
                    animator.Play("Real_adventurer_Flip");
                    weaponAnimator.Play("weapon");
                }
                
            }

            Vector2 position = transform.position;
            position.x = position.x + speed * horizontal;
            position.y = position.y + speed * vertical;
            transform.position = position;
        }
        
    }
}
