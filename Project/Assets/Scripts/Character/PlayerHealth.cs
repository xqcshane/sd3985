using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using Photon.Pun;
using HashTable = ExitGames.Client.Photon.Hashtable;

public class PlayerHealth : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    bool isInvincible;
    float invincibleTimer;
    public float timeInvincible = 0.2f;
    public int maxHealth = 100;
    public int health { get { return currentHealth; } set { currentHealth = value; HashTable table = new HashTable();
            table.Add("hp", currentHealth);
            PhotonNetwork.LocalPlayer.SetCustomProperties(table);
        } }
    int currentHealth;

    private int role;

    public Animator animator;

    void Start()
    {
        role = GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().status;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
        if (currentHealth <= 0)
        {
            GameObject final = GameObject.FindGameObjectWithTag("Result");
            final.GetComponent<Result>().death = true;
            Destroy(gameObject);

        }
    }
    public void ChangeHealth(int amount)
    {
        if (role == 0)
        {
            if (amount < 0)
            {
                if (isInvincible)
                    return;

                isInvincible = true;
                invincibleTimer = timeInvincible;
            }

            /*
            if (amount < 0)
            {
                animator.Play("Adventurer_hit");
            }
            */

            animator.Play("Adventurer_hit");
            currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
            Debug.Log(currentHealth + "/" + maxHealth);
            this.gameObject.GetComponent<PlayerMove>().NotHit = false;
            Invoke("ChangeAnimation", 0.8333333333333333333333333333333f);

            HashTable table = new HashTable();
            table.Add("hp", currentHealth);
            PhotonNetwork.LocalPlayer.SetCustomProperties(table);
        }
    }

    public override void OnPlayerPropertiesUpdate(Photon.Realtime.Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if (role == 1)
        {
            currentHealth = (int)changedProps["hp"];
            Debug.Log(currentHealth + "/" + maxHealth);
        }
    }

    private void ChangeAnimation()
    {
        this.gameObject.GetComponent<PlayerMove>().NotHit = true;
    }
}
