using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using HashTable = ExitGames.Client.Photon.Hashtable;
using System.Data;

public class CheckGun : MonoBehaviourPunCallbacks
{
    private PlayerAim myaim;
    private int role;
    // Start is called before the first frame update
    void Start()
    {
        role = GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().status;
        myaim = this.transform.GetComponent<PlayerAim>();
    }

    // Update is called once per frame
    void Update()
    {
        SameGun(myaim.currentweaponindex);
    }

    public void SameGun(int GunIndex)
    {
        HashTable table = new HashTable();
        table.Add("GunIndex", GunIndex);
        PhotonNetwork.LocalPlayer.SetCustomProperties(table);
    }

    public override void OnPlayerPropertiesUpdate(Photon.Realtime.Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if (role == 1 && changedProps.ContainsKey("GunIndex"))
        {
            myaim.currentweaponindex = (int)changedProps["GunIndex"];
        }
    }

}
