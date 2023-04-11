using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    private Transform aimtransform;
    public GameObject bullet;
    private Rigidbody2D bulletrb;
    Rigidbody2D rigidbody2d;
    private Vector2 offset;
    //setting the gun
    public float speed;
    public float range;
    public float damage;
    public float firerate=1f;
    public int mode;
    private bool flag = true;
    private float nextfire=0f;
    //setting the sword

    float angle;
    // Start is called before the first frame update
    private void Awake()
    {
        aimtransform = transform.Find("Aim");
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleAim();   
            if (mode == 0)
            {
                NormalShoot();
            }
            if (mode == 1)
            {
                FastShooting();
            }
       
    }
    private void HandleAim()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
        offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);
        angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        aimtransform.rotation = Quaternion.Euler(0, 0, angle);
    }
    private void NormalShoot()
    {
      
        if (Input.GetMouseButtonDown(0) && Time.time >nextfire)
        {
            nextfire = Time.time + firerate;
            GameObject bullets = Instantiate(bullet, aimtransform.position,aimtransform.rotation);
            bulletrb = bullets.GetComponent<Rigidbody2D>();
            bulletrb.velocity = bullets.transform.right * speed;
            Destroy(bullets,range);
          
        }
    }
    private void FastShooting()
    {

        if (Input.GetMouseButton(0) && Time.time > nextfire)
        {
            nextfire = Time.time + firerate;
            GameObject bullets = Instantiate(bullet, aimtransform.position, aimtransform.rotation);
            bulletrb = bullets.GetComponent<Rigidbody2D>();
            bulletrb.velocity = bullets.transform.right * speed;
            Destroy(bullets, range);
        }

    }

}
