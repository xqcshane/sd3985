using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    // �ڵ�һ��֡����֮ǰ���� Start
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // ÿ֡����һ�� Update
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 position = transform.position;
        position.x = position.x + speed * horizontal;
        position.y = position.y + speed * vertical;
        transform.position = position;
    }

  
}
