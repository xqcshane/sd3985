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

                Vector2 position = transform.position;
                position.x = position.x + speed * horizontal;
                position.y = position.y + speed * vertical;
                transform.position = position;
            }
        
    }
}
