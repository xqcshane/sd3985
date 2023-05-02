using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using Photon.Pun;
using HashTable = ExitGames.Client.Photon.Hashtable;
using System.Linq;

public class PlayerHealth : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    bool isInvincible;
    float invincibleTimer;
    public float timeInvincible = 0.2f;
    public int maxHealth = 100;

    public GameObject Music;
    private bool playing = false;

    public int health { get { return currentHealth; } set {
            if (role == 0)
            {
                currentHealth = value;
                HashTable table = new HashTable();
                table.Add("hp", currentHealth);
                PhotonNetwork.LocalPlayer.SetCustomProperties(table);
            }
        } }
    int currentHealth;

    private int role;

    public Animator animator;

    void Start()
    {
        role = GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().status;
        currentHealth = maxHealth;
        Music = GameObject.Find("MusicManager");
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
            GameObject final = GameObject.FindGameObjectWithTag("Status");
            final.GetComponent<Status>().death = true;
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
                Music.transform.GetChild(1).gameObject.SetActive(true);
                StartCoroutine(MyCoroutine());
            }

            /*
            if (amount < 0)
            {
                animator.Play("Adventurer_hit");
            }
            */

            animator.SetBool("rightRun", false);
            animator.SetBool("leftRun", false);
            animator.SetBool("backIdle", false);
            animator.SetBool("backIdle_Flip", false);
            animator.SetBool("hit", true);
            //animator.Play("Adventurer_hit");
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
        if (role == 1 && changedProps.ContainsKey("hp"))
        {
            currentHealth = (int)changedProps["hp"];
            Debug.Log(currentHealth + "/" + maxHealth);
        }
    }

    private void ChangeAnimation()
    {
        this.gameObject.GetComponent<PlayerMove>().NotHit = true;
    }

    private IEnumerator MyCoroutine()
    {
        if (!playing)
        {
            playing = true;
            yield return new WaitForSeconds(0.4f);
            Music.transform.GetChild(1).gameObject.SetActive(false);
            playing = false;
            yield return null;
        }
    }
}
