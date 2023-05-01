using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using HashTable = ExitGames.Client.Photon.Hashtable;
public class TrapController : MonoBehaviourPunCallbacks
{
    public Sprite fireicon;
    public Sprite arrowicon;
    public Sprite thronesicon;
    public Sprite slowicon;
    public Sprite moveicon;
    public Sprite fakeicon;
    public Sprite monstericon;
    public Sprite Bossicon;
    public Sprite skill1;
    public Sprite skill2;
    public Sprite skill3;
    public Sprite skill4;
    public Sprite block;
    public Sprite normal;
    public int index1;
    public int index2;
    public int index3;
    public int skillindex;
    public float cooldowntime1;
    float nextskill1 = 0.0f;
    public float contime1;
    bool skillflag1 = false;
    public GameObject TrapUI1;
    public GameObject TrapUI2;
    public GameObject TrapUI3;
    public GameObject SkillUI;
    int amount1;
    int amount2;
    int amount3;
    bool trap1;
    bool trap2;
    bool trap3;
    [Header("Traps")]
    public GameObject FireTower;
    public GameObject Arrow;
    public GameObject Thrones;
    public GameObject slow;
    public GameObject move;
    public GameObject fake;
    public GameObject monster;
    //public GameObject boss;
    public GameObject nowtrap;
    GameObject[] traps;
    private Controller GameController;
    int PR;
    public GameObject troublemaker;
    public float distance=100.0f;
    GameObject player;
    void Start()
    {
        GameController = GameObject.Find("Controller").GetComponent<Controller>();
        int round = GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().round;
        PR = GameController.PlayerRole;
        if (PR == 1)
        {
            GameObject data = GameObject.FindWithTag("TrapData");
            index1 = data.GetComponent<TrapData>().skillindex1;
            index2 = data.GetComponent<TrapData>().skillindex2;
            index3 = data.GetComponent<TrapData>().skillindex3;
            skillindex = data.GetComponent<TrapData>().skill;
            Sprite[] sprites = { fireicon, arrowicon, thronesicon, slowicon, moveicon, fakeicon, monstericon, Bossicon };
            Sprite[] sprites2 = {skill1,skill2,skill3,skill4 };
            traps = new GameObject[7];
            traps[0] = FireTower;
            traps[1] = Arrow;
            traps[2] = Thrones;
            traps[3] = slow;
            traps[4] = move;
            traps[5] = fake;
            traps[6] = monster;
            if (index1 == 1|| index1 == 3)
            {
                amount1 = 2+round*2;
            }
            else if (index1 == 2 || index1 == 4 || index1 == 5)
            {
                amount1 = 3+round;
            }
            else if (index1 == 6)
            {
                amount1 =2 ;
            }
            else if(index1 == 7)
            {
                amount1 = 2 + round;
            }
            TrapUI1.GetComponent<TrapUI>().ChangeTrapImage(sprites[index1 - 1]);
            TrapUI1.GetComponent<TrapUI>().ChangeTrapNumber(amount1.ToString());
            if (index2 == 1 || index2 == 3)
            {
                amount2 = 2 + round * 2;
            }
            else if (index2 == 2 || index2 == 4 || index2 == 5)
            {
                amount2 = 3 + round;
            }
            else if (index2 == 6)
            {
                amount2 = 2;
            }
            else if (index2 == 7)
            {
                amount2 = 2 + round;
            }
            TrapUI2.GetComponent<TrapUI>().ChangeTrapImage(sprites[index2 - 1]);
            TrapUI2.GetComponent<TrapUI>().ChangeTrapNumber(amount2.ToString());
            if (index3 == 1 || index3 == 3)
            {
                amount2 = 2 + round * 2;
            }
            else if (index3 == 2 || index3 == 4 || index3 == 5)
            {
                amount3 = 3 + round;
            }
            else if (index3 == 6)
            {
                amount3 = 2;
            }
            else if (index3 == 7)
            {
                amount3 = 2 + round;
            }
            TrapUI3.GetComponent<TrapUI>().ChangeTrapImage(sprites[index3 - 1]);
            TrapUI3.GetComponent<TrapUI>().ChangeTrapNumber(amount3.ToString());
            if (skillindex == 1)
            {
                cooldowntime1 = 30.0f;
                SkillUI.GetComponent<Skill>().icon = skill1;
                SkillUI.GetComponent<Skill>().coolDown = cooldowntime1;
                SkillUI.GetComponent<Skill>().changeImage();
            }
            else if (skillindex == 2)
            {
                cooldowntime1 = 15.0f;
                SkillUI.GetComponent<Skill>().icon = skill2;
                SkillUI.GetComponent<Skill>().coolDown = cooldowntime1;
                SkillUI.GetComponent<Skill>().changeImage();
            }
            else if (skillindex == 3)
            {
                cooldowntime1 = 20.0f;
                SkillUI.GetComponent<Skill>().icon = skill3;
                SkillUI.GetComponent<Skill>().coolDown = cooldowntime1;
                SkillUI.GetComponent<Skill>().changeImage();
            }
            else if (skillindex == 4)
            {
                cooldowntime1 = 30.0f;
                SkillUI.GetComponent<Skill>().icon = skill4;
                SkillUI.GetComponent<Skill>().coolDown = cooldowntime1;
                SkillUI.GetComponent<Skill>().changeImage();
            }
            nowtrap = null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        bool flag = GameObject.FindGameObjectWithTag("Controller").GetComponent<Controller>().GameStart;
        if (PR == 1)
        {
            if (flag == false)
            {
                GameObject.Find("TroubleMakeCanvas").transform.GetChild(0).gameObject.SetActive(false);
                GameObject.Find("TroubleMakeCanvas").transform.GetChild(1).gameObject.SetActive(true);
            }
            else
            {
                GameObject.Find("TroubleMakeCanvas").transform.GetChild(0).gameObject.SetActive(true);
                GameObject.Find("TroubleMakeCanvas").transform.GetChild(1).gameObject.SetActive(false);
                troublemaker = GameObject.FindGameObjectWithTag("TroubleMaker");
                player = GameObject.FindGameObjectWithTag("Player");
                distance = Vector2.Distance(troublemaker.transform.position, player.transform.position);
            }
            
          
            if (Input.GetKeyUp(KeyCode.Q) && Time.time > nextskill1 && distance<10)
            {
                SkillUI.GetComponent<Skill>().UseSkill("Q");
                if (skillindex == 1)
                {
                    Debug.Log("NONO");
                    nextskill1 = Time.time + cooldowntime1;
                    //GameObject.Find("MaskCanvas").transform.GetChild(0).GetComponent<Image>().sprite = block;
                    HashTable table = new HashTable();
                    table.Add("TSkill1", true);
                    PhotonNetwork.LocalPlayer.SetCustomProperties(table);
                    skillflag1 = true;
                    contime1 = Time.time + 10.0f;
                    Debug.Log("haha");
                }
                else if (skillindex == 2)
                {
                    nextskill1 = Time.time + cooldowntime1;
                    //GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>().slower = true;
                    HashTable table = new HashTable();
                    table.Add("TSkill2", true);
                    PhotonNetwork.LocalPlayer.SetCustomProperties(table);
                    contime1 = Time.time + 5.0f;
                    skillflag1 = true;
                }
                else if (skillindex == 3)
                {
                    nextskill1 = Time.time + cooldowntime1;
                    //Blast();
                    //GameObject.Find("Skill").GetComponent<SkillController>().flag = false;
                    HashTable table = new HashTable();
                    table.Add("TSkill3", true);
                    PhotonNetwork.LocalPlayer.SetCustomProperties(table);
                    contime1 = Time.time + 10.0f;
                    skillflag1 = true;
                }
                else if (skillindex == 4)
                {
                    nextskill1 = Time.time + cooldowntime1;
                    //GameObject.Find("AdventureUIAndUICamera").transform.GetChild(1).gameObject.SetActive(false);
                    //moreMagic();
                    HashTable table = new HashTable();
                    table.Add("TSkill4", true);
                    PhotonNetwork.LocalPlayer.SetCustomProperties(table);
                    contime1 = Time.time + 10.0f;
                    skillflag1 = true;
                }
            }
            if (index1 == 1 && skillflag1 == true)
            {
                if (Time.time > contime1)
                {
                    //GameObject.Find("MaskCanvas").transform.GetChild(0).GetComponent<Image>().sprite = normal;
                    HashTable table = new HashTable();
                    table.Add("TSkill1", false);
                    PhotonNetwork.LocalPlayer.SetCustomProperties(table);
                    skillflag1 = false;
                }
            }
            else if (index1 == 2 && skillflag1 == true)
            {
                if (Time.time > contime1)
                {
                    //GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>().slower = false;
                    HashTable table = new HashTable();
                    table.Add("TSkill2", false);
                    PhotonNetwork.LocalPlayer.SetCustomProperties(table);
                    skillflag1 = false;
                }
            }
            else if (index1 == 3 && skillflag1 == true)
            {
                if (Time.time > contime1)
                {
                    //GameObject.Find("Skill").GetComponent<SkillController>().flag = true;
                    HashTable table = new HashTable();
                    table.Add("TSkill3", false);
                    PhotonNetwork.LocalPlayer.SetCustomProperties(table);
                    skillflag1 = false;
                }
            }
            else if (index1 == 4 && skillflag1 == true)
            {
                if (Time.time > contime1)
                {
                    //GameObject.Find("AdventureUIAndUICamera").transform.GetChild(1).gameObject.SetActive(true);
                    HashTable table = new HashTable();
                    table.Add("TSkill4", false);
                    PhotonNetwork.LocalPlayer.SetCustomProperties(table);
                    skillflag1 = false;
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                TrapUI1.GetComponent<TrapUI>().OnChooseTrap();
                TrapUI2.GetComponent<TrapUI>().UnChooseTrap();
                TrapUI3.GetComponent<TrapUI>().UnChooseTrap();

                trap1 = true;
                trap2 = false;
                trap3 = false;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                TrapUI1.GetComponent<TrapUI>().UnChooseTrap();
                TrapUI2.GetComponent<TrapUI>().OnChooseTrap();
                TrapUI3.GetComponent<TrapUI>().UnChooseTrap();

                trap1 = false;
                trap2 = true;
                trap3 = false;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                TrapUI1.GetComponent<TrapUI>().UnChooseTrap();
                TrapUI2.GetComponent<TrapUI>().UnChooseTrap();
                TrapUI3.GetComponent<TrapUI>().OnChooseTrap();

                trap1 = false;
                trap2 = false; ;
                trap3 = true;
            }

            if (trap1)
            {
                if (amount1 > 0)
                {
                    nowtrap = traps[index1 - 1];
                }
                else
                {
                    nowtrap = null;
                }
            }
            if (trap2)
            {
                if (amount2 > 0)
                {
                    nowtrap = traps[index2 - 1];

                }
                else
                {
                    nowtrap = null;
                }
            }
            if (trap3)
            {
                if (amount3 > 0)
                {
                    nowtrap = traps[index3 - 1];
                }
                else
                {
                    nowtrap = null;
                }
            }
        
        }
    }
    public void usetrap()
    {
        if (trap1)
        {
            amount1 -= 1;
            if (amount1 < 0)
            {
                amount1 = 0;
            }
            TrapUI1.GetComponent<TrapUI>().ChangeTrapNumber(amount1.ToString());

        }
         if (trap2)
        {
            amount2 -= 1;
            if (amount2 < 0)
            {
                amount2 = 0;
            }
            TrapUI2.GetComponent<TrapUI>().ChangeTrapNumber(amount2.ToString());
        }
        if (trap3)
        {
            amount3 -= 1;
            if (amount3 < 0)
            {
                amount3 = 0;
            }
            TrapUI3.GetComponent<TrapUI>().ChangeTrapNumber(amount3.ToString());
        }
    }

    public void CallEnhenceBoss()
    {
        if (index1 == 8 || index2 == 8 || index3 == 8)
        {
            HashTable table = new HashTable();
            table.Add("IsEnhence", true);
            PhotonNetwork.LocalPlayer.SetCustomProperties(table);
        }
            
    }

}
