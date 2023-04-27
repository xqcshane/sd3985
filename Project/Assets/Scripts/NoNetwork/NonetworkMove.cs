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

    public bool NotHit;

    public Animator animator;

    private void Start()
    {
        NotHit = true;
    }

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

            if (NotHit)
            {
                if (horizontal > 0)
                {
                    animator.Play("Adventurer_right");
                }
                else if (horizontal < 0)
                {
                    animator.Play("Adventurer_left");
                }
                else if (vertical > 0)
                {
                    animator.Play("Adventurer_right");
                }
                else if (vertical < 0)
                {
                    animator.Play("Adventurer_right");
                }
                else
                {
                    animator.Play("Real_adventurer");
                }
            }
            

            Vector2 position = transform.position;
            position.x = position.x + speed * horizontal;
            position.y = position.y + speed * vertical;
            transform.position = position;
        }
        
    }
}
