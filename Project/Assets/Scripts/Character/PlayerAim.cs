using System.Collections;
using System.Collections.Generic;
using UnityEditor;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Photon.Pun;


public class PlayerAim : MonoBehaviour
{
    private Transform aimtransform;
    GameObject bullet;
    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject bullet3;
    public GameObject bullet4;
    private Rigidbody2D bulletrb;
   
    Rigidbody2D rigidbody2d;
    private Vector2 offset;
    //setting the Staff
    [Header("Normal Staff")]
    public float speed=20;
    public float range=0.5f;
    public float damage = 10.0f;
    public float firerate=0.5f;
    private float nextfire=0f;
    [Header("ShotGun Staff")]
    public float speed1=10;
    public float range1=0.5f;
    public float damage1 = 20.0f;
    public float firerate1 = 1f;
    private float nextfire1 = 0f;
    [Header("Bomb Staff")]
    public float speed2 = 5;
    public float range2 = 0.5f;
    public float damage2 = 40.0f;
    public float firerate2 = 1f;
    private float nextfire2 = 0f;
    [Header("MachineGun Staff")]
    public float speed3 = 25;
    public float range3 = 0.3f;
    public float damage3 = 2.0f;
    public float firerate3 = 0.01f;
    private float nextfire3 = 0f;
    //setting the weapon
    int totalweapon = 2;
    public int currentweaponindex;
    public GameObject[] guns;
    public Animator[] animators;
    public Animator nowanimator;
    //public GameObject gunholder;
    //public GameObject currentGun;
    string[] Gunlist = { "normalStaff","shotgunStaff","bombStaff","machineGunStaff"};
    float angle;

    private Controller GameController;
    private int PR;
    public bool suckblood=false;
    // Start is called before the first frame update

    public GameObject Music;
    private bool playing = false;

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        guns=new GameObject[4];
        animators= new Animator[4];
        for(int i=0; i<4; i++)
        {
            guns[i] = transform.GetChild(i).gameObject;
            animators[i] = guns[i].GetComponent<Animator>();    
            guns[i].SetActive(false);
        }
        guns[0].SetActive(true);
        aimtransform = transform.Find(Gunlist[0]);    
        bullet1.GetComponent<Bulletcontrol>().damage = damage;
        bullet2.GetComponent<Bulletcontrol>().damage = damage1;
        bullet3.GetComponent<Bulletcontrol>().damage = damage2;
        bullet4.GetComponent<Bulletcontrol>(). damage = damage3;
        bullet1.GetComponent<Bulletcontrol>().exsittime = range;
        bullet2.GetComponent<Bulletcontrol>().exsittime = range1;
        bullet3.GetComponent<Bulletcontrol>().exsittime = range2;
        bullet4.GetComponent<Bulletcontrol>().exsittime = range3;
        bullet1.GetComponent<Bulletcontrol>().speed = speed;
        bullet2.GetComponent<Bulletcontrol>().speed = speed1;
        bullet3.GetComponent<Bulletcontrol>().speed = speed2;
        bullet4.GetComponent<Bulletcontrol>().speed = speed3;
        bullet = bullet1;
        nowanimator = animators[0];
        currentweaponindex = 0;

        GameController = GameObject.Find("Controller").GetComponent<Controller>();
        PR = GameController.PlayerRole;
        Music = GameObject.Find("MusicManager");

    }

    // Update is called once per frame
    void Update()
    {
        if(PR == 0)
        {
            changegun();
            HandleAim();   
            if (currentweaponindex == 0)
                {
                    NormalShoot();
                }
            else if (currentweaponindex == 1) 
                {
                    ShotGun();
                }
            else if(currentweaponindex == 2)
                {
                    Bomb();
                }
            else if( currentweaponindex == 3) { 
                    MachineGun();   
                }
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
      
        if (Input.GetMouseButton(0) && Time.time >nextfire)
        {
            nextfire = Time.time + firerate;
            float realangle = angle + 45.0f;
            Quaternion rotation= Quaternion.Euler(0, 0, realangle);
            GameObject bullets = PhotonNetwork.Instantiate(bullet.name, aimtransform.position,rotation);
            if (suckblood)
            {
                int num = Random.Range(1, 100);
                if(num>90)
                {
                    this.GetComponent<PlayerHealth>().health += 2;
                }
            }
            //bullets.GetComponent<Bulletcontrol>().speed = speed;
            // bullets.GetComponent<Bulletcontrol>().exsittime = range;
            /* bulletrb = bullets.GetComponent<Rigidbody2D>();
             bulletrb.velocity = bullets.transform.right * speed;
             Destroy(bullets,range);*/

            Music.transform.GetChild(2).gameObject.SetActive(true);
            StartCoroutine(MyCoroutine());

        }
    }
    private void FastShooting()
    {

        if (Input.GetMouseButton(0) && Time.time > nextfire)
        {
            nextfire = Time.time + firerate;
            float realangle = angle + 45.0f;
            Quaternion rotation = Quaternion.Euler(0, 0, realangle);
            GameObject bullets = PhotonNetwork.Instantiate(bullet.name, aimtransform.position, rotation);
            bulletrb = bullets.GetComponent<Rigidbody2D>();
            bulletrb.velocity = bullets.transform.right * speed;
            Destroy(bullets, range);
        }

    }

    private void ShotGun()
    {
        if (Input.GetMouseButton(0) && Time.time > nextfire1)
        {
            nextfire1 = Time.time + firerate1;
            float realangle1 = angle + 45.0f;
            float realangle2 = angle + 20.0f;
            float realangle3= angle + 70.0f;
            Quaternion rotation1 = Quaternion.Euler(0, 0, realangle1);
            Quaternion rotation2 = Quaternion.Euler(0, 0, realangle2);
            Quaternion rotation3 = Quaternion.Euler(0, 0, realangle3);
            GameObject[] bullets = { PhotonNetwork.Instantiate(bullet.name, aimtransform.position, rotation3), PhotonNetwork.Instantiate(bullet.name, aimtransform.position, rotation1), PhotonNetwork.Instantiate(bullet.name, aimtransform.position, rotation2) };
            if (suckblood)
            {
                int num = Random.Range(1, 100);
                if (num > 90)
                {
                    this.GetComponent<PlayerHealth>().health += 2;
                }
            }
            /*  for (int i = 0; i < bullets.Length; i++)
              {

                  bulletrb = bullets[i].GetComponent<Rigidbody2D>();
                  bulletrb.velocity = bullets[i].transform.right * speed;
                  Destroy(bullets[i], range1);
              }*/

        }
    }
    private void Bomb()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextfire)
        {
            nextfire = Time.time + firerate;
            float realangle = angle + 45.0f;
            Quaternion rotation = Quaternion.Euler(0, 0, realangle);
            GameObject bullets = PhotonNetwork.Instantiate(bullet.name, aimtransform.position, rotation);
            if (suckblood)
            {
                int num = Random.Range(1, 100);
                if (num > 90)
                {
                    this.GetComponent<PlayerHealth>().health += 2;
                }
            }
            /* bulletrb = bullets.GetComponent<Rigidbody2D>();
             bulletrb.velocity = bullets.transform.right * speed;
             Destroy(bullets, range2);*/

        }
    }
    private void MachineGun()
    {
        if (Input.GetMouseButton(0) && Time.time > nextfire)
        {
            nextfire = Time.time + firerate3;
            float realangle = angle + 45.0f;
            Quaternion rotation = Quaternion.Euler(0, 0, realangle);
            GameObject bullets = PhotonNetwork.Instantiate(bullet.name, aimtransform.position, rotation);
            if (suckblood)
            {
                int num = Random.Range(1, 100);
                if (num > 90)
                {
                    this.GetComponent<PlayerHealth>().health += 2;
                }
            }
            /* bulletrb = bullets.GetComponent<Rigidbody2D>();
             bulletrb.velocity = bullets.transform.right * speed;

             Destroy(bullets, range3);*/
        }
    }
    private void changegun()
    {
        if (currentweaponindex == 0)
        {
            guns[0].SetActive(true);
            aimtransform = transform.Find(Gunlist[0]);
            this.gameObject.GetComponent<PlayerMove>().weaponAnimator = animators[0];
            this.gameObject.GetComponent<PlayerMove>().A1 = "weapon";
            this.gameObject.GetComponent<PlayerMove>().A2 = "weapon_flip";
            guns[1].SetActive(false);
            guns[2].SetActive(false);
            guns[3].SetActive(false);
            bullet = bullet1;
        }
        else if (currentweaponindex == 1)
        {
            guns[1].SetActive(true);
            aimtransform = transform.Find(Gunlist[1]);
            this.gameObject.GetComponent<PlayerMove>().weaponAnimator = animators[1];
            this.gameObject.GetComponent<PlayerMove>().A1 = "weapon2";
            this.gameObject.GetComponent<PlayerMove>().A2 = "weapon2_flip";
            
            guns[0].SetActive(false);
            guns[2].SetActive(false);
            guns[3].SetActive(false);
            bullet = bullet2;
        }
        else if (currentweaponindex == 2)
        {
            guns[2].SetActive(true);
            aimtransform = transform.Find(Gunlist[2]);
            this.gameObject.GetComponent<PlayerMove>().weaponAnimator = animators[2];
            this.gameObject.GetComponent<PlayerMove>().A1 = "weapon3";
            this.gameObject.GetComponent<PlayerMove>().A2 = "weapon3_flip";
            
            guns[0].SetActive(false);
            guns[1].SetActive(false);
            guns[3].SetActive(false);
            bullet = bullet3;
        }
        else if (currentweaponindex==3)
        {
            guns[3].SetActive(true);
            aimtransform = transform.Find(Gunlist[3]);
            this.gameObject.GetComponent<PlayerMove>().weaponAnimator = animators[3];
            this.gameObject.GetComponent<PlayerMove>().A1 = "weapon4";
            this.gameObject.GetComponent<PlayerMove>().A2 = "weapon4_flip";
            guns[0].SetActive(false);
            guns[1].SetActive(false);
            guns[2].SetActive(false);
            bullet = bullet4;
        }
    }

    private IEnumerator MyCoroutine()
    {
        if (!playing)
        {
            playing = true;
            yield return new WaitForSeconds(0.4f);
            Music.transform.GetChild(2).gameObject.SetActive(false);
            playing = false;
            yield return null;
        }
    }
}
