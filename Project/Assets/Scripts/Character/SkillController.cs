using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillController : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite healingicon;
    public Sprite speedupicon;
    public Sprite Blasticon;
    public Sprite magicicon;
    public Sprite clearicon;
    public Sprite Bonusicon;
    public Sprite Invincicon;
    public Sprite Suckicon;
    public Sprite Moveqicon;
    public float cooldowntime1;
    float nextskill1 = 0.0f;
    public float cooldowntime2;
    float nextskill2 = 0.0f;
    bool skillflag1 = false;
    bool skillflag2=false;
    public float contime1;
    public float contime2;
    public int index1;
    public int index2;
    public GameObject SkillUI1;
    public GameObject SkillUI2;
    public GameObject player;
    GameObject sightmask;
    public int PR;
    void Start()
    {
        GameObject data = GameObject.FindWithTag("SkillData");
        index1 = data.GetComponent<SkillData>().skillindex1;
        index2= data.GetComponent<SkillData>().skillindex2;
        player = GameObject.FindWithTag("Player");
        sightmask = GameObject.FindGameObjectWithTag("SightMask");
        PR = GameObject.Find("Controller").GetComponent<Controller>().PlayerRole;
        if (index1 == 1)
        {
            cooldowntime1 = 10.0f;
            SkillUI1.GetComponent<Skill>().icon = healingicon;
            SkillUI1.GetComponent<Skill>().coolDown = cooldowntime1;
            SkillUI1.GetComponent<Skill>().changeImage();
        }
        else if (index1 == 2)
        {
            cooldowntime1 = 15.0f;
            SkillUI1.GetComponent<Skill>().icon = speedupicon;
            SkillUI1.GetComponent<Skill>().coolDown = cooldowntime1;
            SkillUI1.GetComponent<Skill>().changeImage();
        }
        else if (index1 == 3)
        {
            cooldowntime1 = 20.0f;
            SkillUI1.GetComponent<Skill>().icon = Blasticon;
            SkillUI1.GetComponent<Skill>().coolDown = cooldowntime1;
            SkillUI1.GetComponent<Skill>().changeImage();
        }
        else if (index1 == 4)
        {
            cooldowntime1 = 15.0f;
            SkillUI1.GetComponent<Skill>().icon = magicicon;
            SkillUI1.GetComponent<Skill>().coolDown = cooldowntime1;
            SkillUI1.GetComponent<Skill>().changeImage();
        }
        else if (index1 == 5)
        {
            cooldowntime1 = 30.0f;
            SkillUI1.GetComponent<Skill>().icon = clearicon;
            SkillUI1.GetComponent<Skill>().coolDown = cooldowntime1;
            SkillUI1.GetComponent<Skill>().changeImage();
        }
        else if(index1 == 6)
        {
            cooldowntime1 = 20.0f;
            SkillUI1.GetComponent<Skill>().icon = Bonusicon;
            SkillUI1.GetComponent<Skill>().coolDown = cooldowntime1;
            SkillUI1.GetComponent<Skill>().changeImage();
        }
        else if (index1 == 7)
        {
            cooldowntime1 = 25.0f;
            SkillUI1.GetComponent<Skill>().icon = Invincicon;
            SkillUI1.GetComponent<Skill>().coolDown = cooldowntime1;
            SkillUI1.GetComponent<Skill>().changeImage();
        }
        else if (index1 == 8)
        {
            SkillUI1.GetComponent<Skill>().icon = Suckicon;
            SkillUI1.GetComponent<Skill>().changeImage();
        }
        else if (index1 == 9)
        {
            SkillUI1.GetComponent<Skill>().icon = Moveqicon;
            SkillUI1.GetComponent<Skill>().changeImage();
        }
        if (index2 == 1)
        {
            cooldowntime2 = 10.0f;
            SkillUI2.GetComponent<Skill>().icon = healingicon;
            SkillUI2.GetComponent<Skill>().coolDown = cooldowntime2;
            SkillUI2.GetComponent<Skill>().changeImage();
        }
        else if (index2 == 2)
        {
            cooldowntime2 = 15.0f;
            SkillUI2.GetComponent<Skill>().icon = speedupicon;
            SkillUI2.GetComponent<Skill>().coolDown = cooldowntime2;
            SkillUI2.GetComponent<Skill>().changeImage();
        }
        else if (index2 == 3)
        {
            cooldowntime2 = 20.0f;
            SkillUI2.GetComponent<Skill>().icon = Blasticon;
            SkillUI2.GetComponent<Skill>().coolDown = cooldowntime2;
            SkillUI2.GetComponent<Skill>().changeImage();
        }
        else if (index2 == 4)
        {
            cooldowntime2 = 15.0f;
            SkillUI2.GetComponent<Skill>().icon = magicicon;
            SkillUI2.GetComponent<Skill>().coolDown = cooldowntime2;
            SkillUI2.GetComponent<Skill>().changeImage();
        }
        else if (index2 == 5)
        {
            cooldowntime2 = 30.0f;
            SkillUI2.GetComponent<Skill>().icon = clearicon;
            SkillUI2.GetComponent<Skill>().coolDown = cooldowntime2;
            SkillUI2.GetComponent<Skill>().changeImage();
        }
        else if (index2 == 6)
        {
            cooldowntime2 = 20.0f;
            SkillUI2.GetComponent<Skill>().icon = Bonusicon;
            SkillUI2.GetComponent<Skill>().coolDown = cooldowntime1;
            SkillUI2.GetComponent<Skill>().changeImage();
        }
        else if (index2 == 7)
        {
            cooldowntime1 = 25.0f;
            SkillUI2.GetComponent<Skill>().icon = Invincicon;
            SkillUI2.GetComponent<Skill>().coolDown = cooldowntime1;
            SkillUI2.GetComponent<Skill>().changeImage();
        }
        else if (index2 == 8)
        {
            SkillUI2.GetComponent<Skill>().icon = Suckicon;
            SkillUI2.GetComponent<Skill>().changeImage();
        }
        else if (index2 == 9)
        {
            SkillUI2.GetComponent<Skill>().icon = Moveqicon;
            SkillUI2.GetComponent<Skill>().changeImage();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (PR == 0)
        {

            if (Input.GetKeyDown(KeyCode.Q) && Time.time > nextskill1)
            {
                SkillUI1.GetComponent<Skill>().UseSkill("Q");
                if (index1 == 1)
                {
                    nextskill1 = Time.time + cooldowntime1;
                    addHealth();
                    Debug.Log("haha");
                }
                else if (index1 == 2)
                {
                    nextskill1 = Time.time + cooldowntime1;
                    IncreaseSpeed();
                    contime1 = Time.time + 5.0f;
                    skillflag1 = true;
                }
                else if (index1 == 3)
                {
                    nextskill1 = Time.time + cooldowntime1;
                    Blast();
                    contime1 = Time.time + 5.0f;
                    skillflag1 = true;
                }
                else if (index1 == 4)
                {
                    nextskill1 = Time.time + cooldowntime1;
                    moreMagic();
                    contime1 = Time.time + 5.0f;
                    skillflag1 = true;
                }
                else if (index1 == 5)
                {
                    nextskill1 = Time.time + cooldowntime1;
                    Clear();
                    contime1 = Time.time + 10.0f;
                    skillflag1 = true;
                }
                else if(index1 == 6)
                {
                    nextskill1 = Time.time + cooldowntime1;
                    Clear();
                    contime1 = Time.time + 10.0f;
                    skillflag1 = true;
                }

            }
            //update the skill
            if (index1 == 2 && skillflag1 == true)
            {
                if (Time.time > contime1)
                {
                    player.GetComponent<PlayerMove>().speed /= 1.5f;
                    skillflag1 = false;
                }
            }
            else if (index1 == 3 && skillflag1 == true)
            {
                if (Time.time > contime1)
                {
                    player.GetComponent<PlayerAim>().firerate += 0.2f;
                    player.GetComponent<PlayerAim>().firerate1 += 0.2f;
                    player.GetComponent<PlayerAim>().firerate2 += 0.2f;
                    player.GetComponent<PlayerAim>().speed3 -= 10f;
                    skillflag1 = false;
                }
            }
            else if (index1 == 4 && skillflag1 == true)
            {
                if (Time.time > contime1)
                {
                    player.GetComponent<PlayerAim>().damage -= 10;
                    player.GetComponent<PlayerAim>().damage1 -= 10;
                    player.GetComponent<PlayerAim>().damage2 -= 20;
                    player.GetComponent<PlayerAim>().damage3 -= 5;
                    skillflag1 = false;
                }
            }
            else if (index1 == 5 && skillflag1 == true)
            {
                if (Time.time > contime1)
                {
                    sightmask.transform.GetChild(0).gameObject.SetActive(true);
                    skillflag1 = false;
                }
            }

            // E skill
            if (Input.GetKeyDown(KeyCode.E) && Time.time > nextskill2)
            {
                SkillUI2.GetComponent<Skill>().UseSkill("E");
                if (index2 == 1)
                {
                    nextskill2 = Time.time + cooldowntime2;
                    addHealth();
                    Debug.Log("haha");
                }
                else if (index2 == 2)
                {
                    nextskill2 = Time.time + cooldowntime2;
                    IncreaseSpeed();
                    contime2 = Time.time + 5.0f;
                    skillflag2 = true;
                }
                else if (index2 == 3)
                {
                    nextskill2 = Time.time + cooldowntime2;
                    Blast();
                    contime2 = Time.time + 5.0f;
                    skillflag2 = true;
                }
                else if (index2 == 4)
                {
                    nextskill2 = Time.time + cooldowntime2;
                    moreMagic();
                    contime2 = Time.time + 5.0f;
                    skillflag2 = true;
                }
                else if (index2 == 5)
                {
                    nextskill2 = Time.time + cooldowntime2;
                    Clear();
                    contime2 = Time.time + 10.0f;
                    skillflag2 = true;
                }
            }

            // update skill for E
            if (index2 == 2 && skillflag2 == true)
            {
                if (Time.time > contime2)
                {
                    player.GetComponent<PlayerMove>().speed /= 1.5f;
                    skillflag2 = false;
                }
            }
            else if (index2 == 3 && skillflag2 == true)
            {
                if (Time.time > contime2)
                {
                    player.GetComponent<PlayerAim>().firerate += 0.2f;
                    player.GetComponent<PlayerAim>().firerate1 += 0.2f;
                    player.GetComponent<PlayerAim>().firerate2 += 0.2f;
                    player.GetComponent<PlayerAim>().speed3 -= 10f;
                    skillflag2 = false;
                }
            }
            else if (index2 == 4 && skillflag2 == true)
            {
                if (Time.time > contime2)
                {
                    player.GetComponent<PlayerAim>().damage -= 10;
                    player.GetComponent<PlayerAim>().damage1 -= 10;
                    player.GetComponent<PlayerAim>().damage2 -= 20;
                    player.GetComponent<PlayerAim>().damage3 -= 5;
                    skillflag2 = false;
                }
            }
            else if (index2 == 5 && skillflag2 == true)
            {
                if (Time.time > contime2)
                {
                    sightmask.transform.GetChild(0).gameObject.SetActive(true);
                    skillflag2 = false;
                }
            }
        }
        else if (PR == 1)
        {

        }
    }

    // skill for add health
    void addHealth()
    {
        player.GetComponent<PlayerHealth>().health +=20;
    }
    //skill for speed up and decrese speed
    void IncreaseSpeed()
    {
        player.GetComponent<PlayerMove>().speed *= 1.5f;
    }
 
    //blast
    void Blast()
    {
        player.GetComponent<PlayerAim>().firerate -= 0.4f;
        player.GetComponent<PlayerAim>().firerate1 -= 0.4f;
        player.GetComponent<PlayerAim>().firerate2 -= 0.4f;
        player.GetComponent<PlayerAim>().speed3 += 10f;
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

    void Clear()
    {
        sightmask.transform.GetChild(0).gameObject.SetActive(false);
        Debug.Log("kk");
    }
    void Bonus()
    {

    }
    void unclear()
    {

        if (Time.time > contime2)
        {
            sightmask.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
