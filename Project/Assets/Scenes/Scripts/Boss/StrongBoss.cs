using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using HashTable = ExitGames.Client.Photon.Hashtable;
 
public class StrongBoss : MonoBehaviourPunCallbacks
{
    private int role;
    private void Start()
    {
        role = GameObject.Find("Controller").GetComponent<Controller>().PlayerRole;
        if(role == 1)
        {
            GameObject.FindGameObjectWithTag("TrapController").GetComponent<TrapController>().CallEnhenceBoss();
        }
        
    }
    public void stronge()
    {
        this.GetComponent<BossFollow>().health = this.GetComponent<BossFollow>().health * 1.5f;
        this.GetComponent<BossFollow>().speed=this.GetComponent<BossFollow>().speed +=0.5f;
        GameObject.Find("EmojiSystem").transform.GetChild(0).transform.GetChild(1).gameObject.GetComponent<BossHealthBar>().maxhealthPoint = 300f;
        GameObject.Find("EmojiSystem").transform.GetChild(0).transform.GetChild(1).gameObject.GetComponent<BossHealthBar>().healthPoint = 300f;
    }

    public override void OnPlayerPropertiesUpdate(Photon.Realtime.Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if (role == 0 && changedProps.ContainsKey("IsEnhence"))
        {
            stronge();
        }
    }

}
