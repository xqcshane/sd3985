using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    // Start is called before the first frame update
    public string skill1;
    public string skill2;
    public float cooldowntime1;
    float nextskill1 = 0.0f;
    public float cooldowntime2;
    float nextskill2 = 0.0f;
    bool skillflag1;
    bool skillflag2;
    public float contime1;
    public float contime2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && Time.time > nextskill1)
        {
            nextskill1 = Time.time + cooldowntime1;
            addHealth();
            Debug.Log("haha");
        }
        if (Input.GetKeyDown(KeyCode.E) && Time.time > nextskill2) 
        {
            nextskill2 = Time.time + cooldowntime2;
            Blast();
            IncreaseSpeed();

        }
        if (skill2.Equals("sp")&& skillflag2==true)
        {
            // Debug.Log("jj");
            unBlast();
            speedingdown();
        }
    }
    // skill for add health
    void addHealth()
    {
        cooldowntime1=10;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerHealth>().health +=20;
    }
    //skill for speed up and decrese speed
    void IncreaseSpeed()
    {
        cooldowntime2 = 10;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerMove>().speed += 0.02f;
        skillflag2 = true;
        contime2 = Time.time + 5.0f;
    }
    void speedingdown()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (Time.time > contime2)
        {
            player.GetComponent<PlayerMove>().speed -= 0.02f;
            skillflag2 = false;
        }
       
    }
    //blast
    void Blast()
    {
        cooldowntime2 = 10;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerAim>().firerate -= 0.4f;
        player.GetComponent<PlayerAim>().firerate1 -= 0.4f;
        player.GetComponent<PlayerAim>().firerate2 -= 0.4f;
        player.GetComponent<PlayerAim>().speed3 += 10f;
        skillflag2 = true;
        contime2 = Time.time + 5.0f;
    }
    void unBlast()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (Time.time > contime2)
        {
            player.GetComponent<PlayerAim>().firerate += 0.2f;
            player.GetComponent<PlayerAim>().firerate1 += 0.2f;
            player.GetComponent<PlayerAim>().firerate2 += 0.2f;
            player.GetComponent<PlayerAim>().speed3 -= 10f;
            skillflag2 = false;
        }
    }
    void moreMagic()
    {
        cooldowntime2 = 10;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerAim>().damage += 10;
        player.GetComponent<PlayerAim>().damage1 += 10;
        player.GetComponent<PlayerAim>().damage2 += 20;
        player.GetComponent<PlayerAim>().damage3 += 5;
        skillflag2 = true;
        contime2 = Time.time + 5.0f;
    }
    void unmagic()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (Time.time > contime2)
        {
            player.GetComponent<PlayerAim>().damage -= 10;
            player.GetComponent<PlayerAim>().damage1 -= 10;
            player.GetComponent<PlayerAim>().damage2 -= 20;
            player.GetComponent<PlayerAim>().damage3 -= 5;
            skillflag2 = false;
        }
    }

}
