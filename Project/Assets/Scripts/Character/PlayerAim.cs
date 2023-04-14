using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    private Transform aimtransform;
    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject bullet3;
    public GameObject bullet4;
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
    //setting the weapon
    int totalweapon = 2;
    public int currentweaponindex;
    public GameObject[] guns;
    public GameObject gunholder;
    public GameObject currentGun;
    string[] Gunlist = { "normalStaff","shotgunStaff","bombStaff","machineGunStaff"};
    float angle;
    // Start is called before the first frame update
    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        guns=new GameObject[4];
        for(int i=0; i<4; i++)
        {
            guns[i] = transform.GetChild(i).gameObject;
            guns[i].SetActive(false);
        }
        guns[0].SetActive(true);
        aimtransform = transform.Find(Gunlist[0]);
    }

    // Update is called once per frame
    void Update()
    {
        changegun();
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
        angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg-45.0f;
        aimtransform.rotation = Quaternion.Euler(0, 0, angle);
    }
    private void NormalShoot()
    {
      
        if (Input.GetMouseButtonDown(0) && Time.time >nextfire)
        {
            nextfire = Time.time + firerate;
            float realangle = angle + 45.0f;
            Quaternion rotation= Quaternion.Euler(0, 0, realangle);
            GameObject bullets = Instantiate(bullet, aimtransform.position,rotation);
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
            float realangle = angle + 45.0f;
            Quaternion rotation = Quaternion.Euler(0, 0, realangle);
            GameObject bullets = Instantiate(bullet, aimtransform.position, rotation);
            bulletrb = bullets.GetComponent<Rigidbody2D>();
            bulletrb.velocity = bullets.transform.right * speed;
            Destroy(bullets, range);
        }

    }
    private void changegun()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            guns[0].SetActive(true);
            aimtransform = transform.Find(Gunlist[0]);
            guns[1].SetActive(false);
            guns[2].SetActive(false);
            guns[3].SetActive(false);
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            guns[1].SetActive(true);
            aimtransform = transform.Find(Gunlist[1]);
            guns[0].SetActive(false);
            guns[2].SetActive(false);
            guns[3].SetActive(false);
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            guns[2].SetActive(true);
            aimtransform = transform.Find(Gunlist[2]);
            guns[0].SetActive(false);
            guns[1].SetActive(false);
            guns[3].SetActive(false);
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            guns[3].SetActive(true);
            aimtransform = transform.Find(Gunlist[3]);
            guns[0].SetActive(false);
            guns[1].SetActive(false);
            guns[2].SetActive(false);
        }
    }

}
