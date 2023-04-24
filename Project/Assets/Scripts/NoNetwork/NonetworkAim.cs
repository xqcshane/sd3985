using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class NonetworkAim : MonoBehaviour
{
    private Transform aimtransform;
    GameObject bullet;
    public GameObject bullet1;
    private Rigidbody2D bulletrb;

    Rigidbody2D rigidbody2d;
    private Vector2 offset;
    //setting the Staff
    [Header("Normal Staff")]
    public float speed1 = 10;
    public float range1 = 0.5f;
    public float damage1 = 20.0f;
    public float firerate1 = 1f;
    private float nextfire1 = 0f;
    string[] Gunlist = { "normalStaff", "shotgunStaff", "bombStaff", "machineGunStaff" };
    float angle;

    // Start is called before the first frame update
    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        aimtransform = transform.Find(Gunlist[1]);
        bullet1.GetComponent<Nonetworkbullet>().damage = damage1;   
    }

    // Update is called once per frame
    void Update()
    {
            HandleAim();
            ShotGun();
    }
    private void HandleAim()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
        offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);
        angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg - 45.0f;
        aimtransform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void ShotGun()
    {
        if (Input.GetMouseButton(0) && Time.time > nextfire1)
        {
            nextfire1 = Time.time + firerate1;
            float realangle1 = angle + 45.0f;
            float realangle2 = angle + 20.0f;
            float realangle3 = angle + 70.0f;
            Quaternion rotation1 = Quaternion.Euler(0, 0, realangle1);
            Quaternion rotation2 = Quaternion.Euler(0, 0, realangle2);
            Quaternion rotation3 = Quaternion.Euler(0, 0, realangle3);
            GameObject[] bullets = { Instantiate(bullet1, aimtransform.position, rotation3), Instantiate(bullet1, aimtransform.position, rotation1), Instantiate(bullet1, aimtransform.position, rotation2) };
            for (int i = 0; i < bullets.Length; i++)
            {
                bulletrb = bullets[i].GetComponent<Rigidbody2D>();
                bulletrb.velocity = bullets[i].transform.right * speed1;
                Destroy(bullets[i], range1);
            }

        }
    }


}
