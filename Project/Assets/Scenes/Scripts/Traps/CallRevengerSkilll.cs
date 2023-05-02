using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using HashTable = ExitGames.Client.Photon.Hashtable;
using UnityEngine.UI;
using System.Data;


public class CallRevengerSkilll : MonoBehaviourPunCallbacks
{
    public Sprite block;
    public Sprite normal;

    private int PR;
    // Start is called before the first frame update
    void Start()
    {
        PR = GameObject.Find("Controller").GetComponent<Controller>().PlayerRole;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnPlayerPropertiesUpdate(Photon.Realtime.Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if (PR == 0 )
        {
            if (changedProps.ContainsKey("TSkill1"))
            {
                CallSkill1((bool)changedProps["TSkill1"]);
            }
            if (changedProps.ContainsKey("TSkill2"))
            {
                CallSkill2((bool)changedProps["TSkill2"]);
            }
            if (changedProps.ContainsKey("TSkill3"))
            {
                CallSkill3((bool)changedProps["TSkill3"]);
            }
            if (changedProps.ContainsKey("TSkill4"))
            {
                CallSkill4((bool)changedProps["TSkill4"]);
            }
        }
    }

    private void CallSkill1(bool ison)
    {
        if (ison)
        {
            GameObject.Find("MaskCanvas").transform.GetChild(0).GetComponent<Image>().sprite = block;
        }
        else
        {
            GameObject.Find("MaskCanvas").transform.GetChild(0).GetComponent<Image>().sprite = normal;
        }
    }

    private void CallSkill2(bool ison)
    {
        if (ison)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>().slower = true;
        }
        else
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>().slower = false;
        }
    }
    private void CallSkill3(bool ison)
    {
        if (ison)
        {
            GameObject.Find("Skill").GetComponent<SkillController>().flag = false;
        }
        else
        {
            GameObject.Find("Skill").GetComponent<SkillController>().flag = true;
        }
    }
    private void CallSkill4(bool ison)
    {
        if (ison)
        {
            GameObject.Find("AdventureUIAndUICamera").transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            GameObject.Find("AdventureUIAndUICamera").transform.GetChild(1).gameObject.SetActive(true);
        }
    }

}
