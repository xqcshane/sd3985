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
    // Start is called before the first frame update
    void Start()
    {
        EmoA = this.gameObject.GetComponent<Animator>();
        role = GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().status;
        CanUseEmoji = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (CanUseEmoji)
        {
            if (role == 0)
            {
                
                if (Input.GetKeyDown(KeyCode.Alpha1) && Time.time > nextemo)
                {
                    nextemo = Time.time + 5.0f;
                    EmoA.SetBool("Anger", true);
                    conemo = Time.time + 3.0f;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2) && Time.time > nextemo)
                {
                    nextemo = Time.time + 5.0f;
                    EmoA.SetBool("HAHA", true);

                    conemo = Time.time + 3.0f;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3) && Time.time > nextemo)
                {
                    nextemo = Time.time + 5.0f;
                    EmoA.SetBool("CRY", true);
                    conemo = Time.time + 3.0f;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha4) && Time.time > nextemo)
                {
                    nextemo = Time.time + 5.0f;
                    EmoA.SetBool("Good", true);
                    conemo = Time.time + 3.0f;
                }
            }

            if (Time.time > conemo)
            {
                EmoA.SetBool("Good", false);
                EmoA.SetBool("CRY", false);
                EmoA.SetBool("HAHA", false);
                EmoA.SetBool("Anger", false);
            }
        }
    }

    public override void OnPlayerPropertiesUpdate(Photon.Realtime.Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if (role == 1 && changedProps.ContainsKey("hp"))
        {
            //currentHealth = (int)changedProps["hp"];
            //Debug.Log(currentHealth + "/" + maxHealth);
        }
    }
}
