using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using HashTable = ExitGames.Client.Photon.Hashtable;


public class EmojiController : MonoBehaviourPunCallbacks
{
    public Animator EmoA;
    public bool CanUseEmoji;
    private int role;
    float nextemo = 0.0f;
    bool setemo = false;
    float conemo;
    public GameObject SkillUI1;
    public GameObject SkillUI2;
    public GameObject SkillUI3;
    public GameObject SkillUI4;

    public GameObject Music;
    // Start is called before the first frame update
    void Start()
    {
        EmoA = this.gameObject.GetComponent<Animator>();
        role = GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().status;
        CanUseEmoji = false;
        SkillUI1.GetComponent<Skill>().coolDown = 5.0f;
        SkillUI2.GetComponent<Skill>().coolDown = 5.0f;
        SkillUI3.GetComponent<Skill>().coolDown = 5.0f;
        SkillUI4.GetComponent<Skill>().coolDown = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (CanUseEmoji)
        {
            if (role == 1)
            {

                if (Input.GetKeyDown(KeyCode.Alpha1) && Time.time > nextemo)
                {
                    SkillUI1.GetComponent<Skill>().UseSkill("Q");
                    SkillUI2.GetComponent<Skill>().UseSkill("Q");
                    SkillUI3.GetComponent<Skill>().UseSkill("Q");
                    SkillUI4.GetComponent<Skill>().UseSkill("Q");
                    nextemo = Time.time + 5.0f;
                    EmoA.SetBool("Anger", true);

                    Music.transform.GetChild(6).gameObject.SetActive(true);

                    HashTable table = new HashTable();
                    table.Add("Anger", true);
                    PhotonNetwork.LocalPlayer.SetCustomProperties(table);

                    conemo = Time.time + 3.0f;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2) && Time.time > nextemo)
                {
                    SkillUI1.GetComponent<Skill>().UseSkill("Q");
                    SkillUI2.GetComponent<Skill>().UseSkill("Q");
                    SkillUI3.GetComponent<Skill>().UseSkill("Q");
                    SkillUI4.GetComponent<Skill>().UseSkill("Q");
                    nextemo = Time.time + 5.0f;
                    EmoA.SetBool("HAHA", true);

                    Music.transform.GetChild(5).gameObject.SetActive(true);

                    HashTable table = new HashTable();
                    table.Add("HAHA", true);
                    PhotonNetwork.LocalPlayer.SetCustomProperties(table);

                    conemo = Time.time + 3.0f;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3) && Time.time > nextemo)
                {
                    SkillUI1.GetComponent<Skill>().UseSkill("Q");
                    SkillUI2.GetComponent<Skill>().UseSkill("Q");
                    SkillUI3.GetComponent<Skill>().UseSkill("Q");
                    SkillUI4.GetComponent<Skill>().UseSkill("Q");
                    nextemo = Time.time + 5.0f;
                    EmoA.SetBool("CRY", true);

                    Music.transform.GetChild(4).gameObject.SetActive(true);

                    HashTable table = new HashTable();
                    table.Add("CRY", true);
                    PhotonNetwork.LocalPlayer.SetCustomProperties(table);

                    conemo = Time.time + 3.0f;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha4) && Time.time > nextemo)
                {
                    SkillUI1.GetComponent<Skill>().UseSkill("Q");
                    SkillUI2.GetComponent<Skill>().UseSkill("Q");
                    SkillUI3.GetComponent<Skill>().UseSkill("Q");
                    SkillUI4.GetComponent<Skill>().UseSkill("Q");
                    nextemo = Time.time + 5.0f;
                    EmoA.SetBool("Good", true);

                    Music.transform.GetChild(3).gameObject.SetActive(true);

                    HashTable table = new HashTable();
                    table.Add("Good", true);
                    PhotonNetwork.LocalPlayer.SetCustomProperties(table);

                    conemo = Time.time + 3.0f;
                }
            }

            if (Time.time > conemo)
            {
                EmoA.SetBool("Good", false);
                EmoA.SetBool("CRY", false);
                EmoA.SetBool("HAHA", false);
                EmoA.SetBool("Anger", false);
                HashTable table = new HashTable();
                table.Add("Good", false);
                table.Add("CRY", false);
                table.Add("HAHA", false);
                table.Add("Anger", false);
                PhotonNetwork.LocalPlayer.SetCustomProperties(table);

                Music.transform.GetChild(3).gameObject.SetActive(false);
                Music.transform.GetChild(4).gameObject.SetActive(false);
                Music.transform.GetChild(5).gameObject.SetActive(false);
                Music.transform.GetChild(6).gameObject.SetActive(false);
            }
        }
    }

    public override void OnPlayerPropertiesUpdate(Photon.Realtime.Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if (role == 0)
        {
            if (changedProps.ContainsKey("Good"))
            {
                EmoA.SetBool("Good", (bool)changedProps["Good"]);
            }
            if (changedProps.ContainsKey("CRY"))
            {
                EmoA.SetBool("CRY", (bool)changedProps["CRY"]);
            }
            if (changedProps.ContainsKey("HAHA"))
            {
                EmoA.SetBool("HAHA", (bool)changedProps["HAHA"]);
            }
            if (changedProps.ContainsKey("Anger"))
            {
                EmoA.SetBool("Anger", (bool)changedProps["Anger"]);
            }
        }
    }
}
